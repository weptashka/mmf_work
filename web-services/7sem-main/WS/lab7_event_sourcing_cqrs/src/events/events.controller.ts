import { Controller, Get, Param } from '@nestjs/common';
import { EventService } from 'src/events/events.service';

@Controller('events')
export class EventsController {
  constructor(private readonly eventsService: EventService) {}

  @Get()
  findAll() {
    return this.eventsService.findAll();
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.eventsService.findOne(id);
  }
}
