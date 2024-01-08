import { Injectable } from '@nestjs/common';
import { UpdatePetDto } from './dto/update-pet.dto';
import { PrismaService } from 'src/prisma.service';
import { CreatePetDto } from './dto/create-pet.dto';

@Injectable()
export class PetsService {
  constructor(private prisma: PrismaService) {}

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

  async update(id: string, updatePetDto: UpdatePetDto) {
    const pet = await this.prisma.pet.update({
      where: { id },
      data: updatePetDto,
    });

    return pet;
  }

  async remove(id: string) {
    await this.prisma.pet.delete({
      where: { id },
    });
  }
}
