import {
  Controller,
  Get,
  Post,
  Body,
  Param,
  Query,
  UseInterceptors,
  UploadedFile,
} from '@nestjs/common';
import { EventsService } from './events.service';
import { CreateEventDto } from './dto/create-event.dto';
import { SearchEventDto } from './dto/search-event.dto';
import { FileInterceptor } from '@nestjs/platform-express';

@Controller('events')
export class EventsController {
  constructor(private readonly eventsService: EventsService) {}

  @Post()
  create(@Body() createEventDto: CreateEventDto) {
    return this.eventsService.create(createEventDto);
  }
  @Post('/file/json')
  @UseInterceptors(FileInterceptor('file'))
  createByJsonFile(@UploadedFile() file: any) {
    return this.eventsService.createByJsonFile(file);
  }

  @Get()
  findAll() {
    return this.eventsService.findAll();
  }

  @Get('/search')
  searchAll(@Query() query: SearchEventDto) {
    const transformedQuery = {
      ...query,
      ...(query?.status && { status: +query?.status }),
    };

    return this.eventsService.searchAll(transformedQuery);
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.eventsService.findOne(id);
  }

  @Get('/stats/status')
  getStatusStats() {
    return this.eventsService.getStatusStats();
  }

  @Get('/stats/service')
  getServiceStats() {
    return this.eventsService.getServiceStats();
  }

  @Get('/stats/source')
  getSourceStats() {
    return this.eventsService.getSourceStats();
  }

  @Get('/stats/frequency')
  getDateRangeFrequencyStats() {
    return this.eventsService.getDateRangeFrequencyStats();
  }
}
