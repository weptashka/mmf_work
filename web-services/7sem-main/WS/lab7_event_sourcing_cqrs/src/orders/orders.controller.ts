import { Controller, Get, Post, Body, Patch, Param, Res } from '@nestjs/common';

import { OrdersService } from './orders.service';
import { CreateOrderDto } from './dto/create-order.dto';
import { UpdateOrderDto } from './dto/update-order.dto';

@Controller('orders')
export class OrdersController {
  constructor(private readonly ordersService: OrdersService) {}

  @Post()
  create(@Body() createOrderDto: CreateOrderDto, @Res() res) {
    return this.ordersService.create(createOrderDto, res);
  }

  @Get()
  findAll(@Res() res) {
    return this.ordersService.findAll(res);
  }

  @Get(':id')
  findOne(@Param('id') id: string, @Res() res) {
    return this.ordersService.findOne(id, res);
  }

  @Patch(':id')
  update(
    @Param('id') id: string,
    @Body() updateOrderDto: UpdateOrderDto,
    @Res() res,
  ) {
    return this.ordersService.updateOne(id, updateOrderDto, res);
  }
}
