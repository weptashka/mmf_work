import { Injectable } from '@nestjs/common';
import { OnEvent } from '@nestjs/event-emitter';

import { ORDER_EVENT_TYPES } from './entities/order.event.entity';
import { PrismaService } from 'src/prisma/prisma.service';

@Injectable()
export class OrdersHandlers {
  constructor(private readonly prisma: PrismaService) {}

  @OnEvent(ORDER_EVENT_TYPES.ORDER_CREATED)
  async handleOrderCreatedEvent(event: any, res) {
    const order = await this.prisma.order.create({ data: event.payload });

    await this.prisma.snapshot.create({
      data: {
        aggregateId: order.id,
        aggregateType: 'order',
        version: 1,
        payload: order,
      },
    });

    res.send(order);
  }

  @OnEvent(ORDER_EVENT_TYPES.ORDER_UPDATED)
  async handleUpdateOrder(data: any, res) {
    console.log(data._id, data);
    const existedSnapshot = await this.prisma.snapshot.findFirst({
      where: { aggregateId: data.payload.id },
    });

    if (!existedSnapshot) {
      return;
    }

    const newSnapshot = {
      ...existedSnapshot,
      version: (existedSnapshot.version += 1),
      payload: {
        ...(existedSnapshot.payload as any),
        ...data.payload,
      },
    };

    delete newSnapshot.id;

    await this.prisma.snapshot.updateMany({
      where: { aggregateId: data._id },
      data: newSnapshot,
    });

    res.send(newSnapshot?.payload);
  }

  @OnEvent(ORDER_EVENT_TYPES.GET_ALL_ORDERS)
  async handleGetAllOrders(data: any, res) {
    res.send(data.payload);
  }

  @OnEvent(ORDER_EVENT_TYPES.GET_ONE_ORDER)
  async handleGetOneOrder(data: any, res) {
    res.send(data.payload?.payload);
  }
}
