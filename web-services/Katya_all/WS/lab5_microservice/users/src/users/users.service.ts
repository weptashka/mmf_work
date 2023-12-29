import { Injectable } from '@nestjs/common';
import { CreateUserDto } from './dto/create-user.dto';
import { UpdateUserDto } from './dto/update-user.dto';
import { PrismaService } from 'src/prisma.service';

@Injectable()
export class UsersService {
  constructor(private prisma: PrismaService) {}

  async create(createUserDto: CreateUserDto) {
    const user = await this.prisma.user.create({ data: createUserDto });
    return user;
  }

  async findAll() {
    const users = await this.prisma.user.findMany();

    return users;
  }

  async findOne(id: string) {
    const user = await this.prisma.user.findUnique({
      where: { id },
    });

    return user;
  }

  async findCategoryOne(id: string) {
    const user = await this.prisma.user.findUnique({
      where: { id },
    });

    const categoryId = user.favoriteCategoryId;

    const category = await this.prisma.category.findFirst({
      where: { id: categoryId },
    });

    return category;
  }

  async update(id: string, updateUserDto: UpdateUserDto) {
    const pet = await this.prisma.user.update({
      where: { id },
      data: updateUserDto,
    });

    return pet;
  }

  async remove(id: string) {
    await this.prisma.user.delete({
      where: { id },
    });
  }
}
