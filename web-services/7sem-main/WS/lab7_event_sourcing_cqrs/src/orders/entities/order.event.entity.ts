import { v4 as uuidv4 } from 'uuid';

export class OrderEvent {
  aggregateId: string;
  aggregateType: string;
  type: string;
  payload: any;

  constructor(type, payload) {
    this.aggregateId = uuidv4();
    this.aggregateType = 'order';
    this.type = type;
    this.payload = payload;
  }
}

export const ORDER_EVENT_TYPES = {
  ORDER_CREATED: 'ORDER_CREATED',
  GET_ALL_ORDERS: 'GET_ALL_ORDERS',
  GET_ONE_ORDER: 'GET_ONE_ORDER',
  ORDER_UPDATED: 'ORDER_UPDATED',
} as const;
