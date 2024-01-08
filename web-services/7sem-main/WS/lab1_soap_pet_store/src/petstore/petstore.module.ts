import { Module } from '@nestjs/common';

import { PrismaService } from 'src/prisma.service';

import { PetStoreController } from './petstore.controller';
import { PetStoreService } from './petstore.service';

@Module({
  controllers: [PetStoreController],
  providers: [PetStoreService, PrismaService],
})
export class PetStoreModule {}
