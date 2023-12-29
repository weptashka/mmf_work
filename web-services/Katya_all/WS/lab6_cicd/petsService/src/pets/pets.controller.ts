import {
  Controller,
  Get,
  Post,
  Body,
  Param,
  Delete,
  HttpCode,
  Put,
} from '@nestjs/common';
import { PetsService } from './pets.service';
import { CreatePetDto } from './dto/create-pet.dto';
import { UpdatePetDto } from './dto/update-pet.dto';

@Controller('pets')
export class PetsController {
  constructor(private readonly petsService: PetsService) {}

  @Post()
  create(@Body() createPetDto: CreatePetDto) {
    return this.petsService.create(createPetDto);
  }

  @Get()
  findAll() {
    return this.petsService.findAll();
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.petsService.findOne(id);
  }

  @Put(':id')
  updateOne(@Param('id') id: string, @Body() updatePetDto: UpdatePetDto) {
    return this.petsService.updateOne(id, updatePetDto);
  }

  @Delete(':id')
  @HttpCode(204)
  deleteOne(@Param('id') id: string) {
    return this.petsService.deleteOne(id);
  }

  @Get(':id/category')
  findCategoryOne(@Param('id') id: string) {
    return this.petsService.findCategoryOne(id);
  }

  @Get(':id/user')
  findUserOne(@Param('id') id: string) {
    return this.petsService.findUserOne(id);
  }
}
