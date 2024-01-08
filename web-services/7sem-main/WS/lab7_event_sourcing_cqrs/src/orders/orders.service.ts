import { Injectable, ResponseDecoratorOptions } from '@nestjs/common';

import { PrismaService } from 'src/prisma/prisma.service';
import { EmitterService } from 'src/events/emitter.service';

import { CreateOrderDto } from './dto/create-order.dto';
import { UpdateOrderDto } from './dto/update-order.dto';
import { ORDER_EVENT_TYPES, OrderEvent } from './entities/order.event.entity';

@Injectable()
export class OrdersService {
  constructor(
    private readonly prisma: PrismaService,
    readonly eventEmitter: EmitterService,
  ) {}

  async create(createOrderDto: CreateOrderDto, res: ResponseDecoratorOptions) {
    await this.eventEmitter.emitAsync(
      ORDER_EVENT_TYPES.ORDER_CREATED,
      new OrderEvent(ORDER_EVENT_TYPES.ORDER_CREATED, createOrderDto),
      res,
    );
  }

  async findAll(res: ResponseDecoratorOptions) {
    const snapshots = await this.prisma.snapshot.findMany({
      where: { aggregateType: 'order' },
    });

    const data = snapshots.map((snapshot) => ({
      id: snapshot.aggregateId,
      ...(snapshot.payload as any),
    }));

    await this.eventEmitter.emitAsync(
      ORDER_EVENT_TYPES.GET_ALL_ORDERS,
      new OrderEvent(ORDER_EVENT_TYPES.GET_ALL_ORDERS, data),
      res,
    );
  }

  async findOne(id: string, res: ResponseDecoratorOptions) {
    const snapshots = await this.prisma.snapshot.findFirst({
      where: { aggregateId: id },
    });

    await this.eventEmitter.emitAsync(
      ORDER_EVENT_TYPES.GET_ONE_ORDER,
      new OrderEvent(ORDER_EVENT_TYPES.GET_ONE_ORDER, snapshots),
      res,
    );
  }

  async updateOne(
    id: string,
    updateOrderDto: UpdateOrderDto,
    res: ResponseDecoratorOptions,
  ) {
    await this.eventEmitter.emitAsync(
      ORDER_EVENT_TYPES.ORDER_UPDATED,
      new OrderEvent(ORDER_EVENT_TYPES.ORDER_UPDATED, {
        id,
        ...updateOrderDto,
      }),
      res,
    );
  }
}
