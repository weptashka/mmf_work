import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { CategoriesModule } from './categories/categories.module';
import { PrismaService } from './prisma.service';

@Module({
  imports: [CategoriesModule],
  controllers: [AppController],
  providers: [AppService, PrismaService],
})
export class AppModule {}
