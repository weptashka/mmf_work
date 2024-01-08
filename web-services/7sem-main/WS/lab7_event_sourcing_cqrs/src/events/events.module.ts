import { Global, Module } from '@nestjs/common';

import { EmitterService } from './emitter.service';
import { EventsController } from './events.controller';
import { EventService } from './events.service';

@Global()
@Module({
  controllers: [EventsController],
  providers: [EmitterService, EventService],
  exports: [EmitterService],
})
export class EventsModule {}
