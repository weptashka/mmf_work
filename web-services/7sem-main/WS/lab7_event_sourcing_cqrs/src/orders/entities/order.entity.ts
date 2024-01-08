export enum OrderStatus {
  OPEN = 'OPEN',
  SETTLED = 'SETTLED',
  CANCELLED = 'CANCELLED',
}

export enum OrderType {
  BUY = 'BUY',
  SELL = 'SELL',
}

export class Order {
  _id: string;
  userId: string;
  stockId: string;
  quantity: number;
  orderType: OrderType;
  status: OrderStatus;
  createdAt: Date;
}
