import { Module } from '@nestjs/common';
import { PetsModule } from './pets/pets.module';
import { PrismaModule } from './prisma/prisma.module';

@Module({
  imports: [PrismaModule, PetsModule],
})
export class AppModule {}
