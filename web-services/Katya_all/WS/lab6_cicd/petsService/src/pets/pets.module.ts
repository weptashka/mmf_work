import { Module } from '@nestjs/common';
import { PetsController } from './pets.controller';
import { PetsService } from './pets.service';

@Module({
  providers: [PetsService],
  controllers: [PetsController],
})
export class PetsModule {}
