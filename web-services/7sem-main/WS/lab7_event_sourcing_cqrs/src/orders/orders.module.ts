import { Module } from '@nestjs/common';
import { OrdersService } from './orders.service';
import { OrdersController } from './orders.controller';
import { OrdersHandlers } from './orders.handlers';

@Module({
  controllers: [OrdersController],
  providers: [OrdersService, OrdersHandlers],
})
export class OrdersModule {}
