import { OrderStatus, OrderType } from '../entities/order.entity';

export class CreateOrderDto {
  userId: string;
  stockId: string;
  quantity: number;
  orderType: OrderType;
  status: OrderStatus;
  createdAt?: Date;
}
