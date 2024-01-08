import { Module } from '@nestjs/common';

import { PrismaModule } from './prisma/prisma.module';
import { OrdersModule } from './orders/orders.module';
import { EventEmitterModule } from '@nestjs/event-emitter';
import { EventsModule } from './events/events.module';
import { SnapshotsModule } from './snapshots/snapshots.module';

@Module({
  imports: [
    PrismaModule,
    OrdersModule,
    SnapshotsModule,
    EventEmitterModule.forRoot(),
    EventsModule,
  ],
})
export class AppModule {}
