import { Injectable } from '@nestjs/common';
import { EventEmitter2 } from '@nestjs/event-emitter';
import { PrismaService } from 'src/prisma/prisma.service';

@Injectable()
export class EmitterService {
  constructor(
    private readonly prisma: PrismaService,
    private eventEmitter: EventEmitter2,
  ) {}

  async emitAsync(eventName, payload, res) {
    await this.prisma.event.create({ data: payload });

    return this.eventEmitter.emitAsync(eventName, payload, res);
  }
}
