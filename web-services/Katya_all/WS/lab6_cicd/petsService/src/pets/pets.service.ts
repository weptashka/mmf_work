import { Injectable } from '@nestjs/common';
import { UpdatePetDto } from './dto/update-pet.dto';
import { PrismaService } from '../prisma/prisma.service';
import { CreatePetDto } from './dto/create-pet.dto';

@Injectable()
export class PetsService {
  constructor(private readonly prisma: PrismaService) {}

  async create(createPetDto: CreatePetDto) {
    const pet = await this.prisma.pet.create({ data: createPetDto });

    return pet;
  }

  async findAll() {
    const pets = await this.prisma.pet.findMany();

    return pets;
  }

  async findOne(id: string) {
    const pet = await this.prisma.pet.findUnique({
      where: { id },
    });

    return pet;
  }

  async findCategoryOne(id: string) {
    const pet = await this.prisma.pet.findUnique({
      where: { id },
    });

    const categoryId = pet.categoryId;

    const category = await this.prisma.category.findFirst({
      where: { id: categoryId },
    });

    return category;
  }

  async findUserOne(id: string) {
    const pet = await this.prisma.pet.findUnique({
      where: { id },
    });

    const userId = pet.userId;

    const category = await this.prisma.user.findFirst({
      where: { id: userId },
    });

    return category;
  }

  async updateOne(id: string, updatePetDto: UpdatePetDto) {
    const pet = await this.prisma.pet.update({
      where: { id },
      data: updatePetDto,
    });

    return pet;
  }

  async deleteOne(id: string) {
    await this.prisma.pet.delete({
      where: { id },
    });
  }
}
