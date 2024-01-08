import { Injectable } from '@nestjs/common';

import { PrismaService } from 'src/prisma/prisma.service';

@Injectable()
export class EventService {
  constructor(private readonly prisma: PrismaService) {}

  async findAll() {
    const events = await this.prisma.event.findMany({
      where: { aggregateType: 'order' },
    });

    return events;
  }

  async findOne(id: string) {
    const event = await this.prisma.event.findFirst({
      where: { id },
    });

    return event;
  }
}
