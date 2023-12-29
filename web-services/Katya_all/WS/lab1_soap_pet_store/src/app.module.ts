import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';

import { PetStoreModule } from './petstore/petstore.module';

@Module({
  imports: [PetStoreModule, ConfigModule.forRoot()],
})
export class AppModule {}
