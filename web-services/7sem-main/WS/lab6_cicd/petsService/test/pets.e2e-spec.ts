import { Test, TestingModule } from '@nestjs/testing';
import { INestApplication } from '@nestjs/common';
import * as request from 'supertest';
import { AppModule } from '../src/app.module';
import { PrismaService } from '../src/prisma/prisma.service';
import { Category, Pet, User } from '@prisma/client';
import { useContainer } from 'class-validator';

describe('Pet (e2e)', () => {
  let app: INestApplication;
  let prisma: PrismaService;
  let pet: Pet;
  let category: Category;
  let user: User;

  beforeAll(async () => {
    const moduleFixture: TestingModule = await Test.createTestingModule({
      imports: [AppModule],
    }).compile();

    app = moduleFixture.createNestApplication();
    prisma = app.get<PrismaService>(PrismaService);

    useContainer(app.select(AppModule), { fallbackOnErrors: true });

    await app.init();

    category = await prisma.category.create({
      data: {
        name: 'Cats',
        description: 'Fluffy and nice creatures',
      },
    });

    user = await prisma.user.create({
      data: {
        name: 'Ivan Ivanov',
        favoriteCategoryId: category.id,
      },
    });

    pet = await prisma.pet.create({
      data: {
        name: 'Cat1',
        userId: user.id,
        categoryId: category.id,
        status: 'available',
      },
    });

    await prisma.pet.create({
      data: {
        name: 'Cat2',
        userId: user.id,
        categoryId: category.id,
        status: 'available',
      },
    });
  });

  afterAll(async () => {
    // await prisma.truncate();
    // await prisma.resetSequences();
    await prisma.$disconnect();
    await app.close();
  });

  afterEach(async () => {
    // TODO: use transactions and transaction rollback once prisma supports it
  });

  describe('GET /pets', () => {
    it('returns a list of pets', async () => {
      const { status, body } = await request(app.getHttpServer()).get('/pets');

      expect(status).toBe(200);
      expect(body).toStrictEqual(expect.arrayContaining([pet]));
    });
  });

  describe('GET /pets/:id', () => {
    it('returns a pet', async () => {
      const { status, body } = await request(app.getHttpServer()).get(
        `/pets/${pet.id}`,
      );

      expect(status).toBe(200);
      expect(body).toStrictEqual(pet);
    });

    it('returns a pet category', async () => {
      const { status, body } = await request(app.getHttpServer()).get(
        `/pets/${pet.id}/category`,
      );

      expect(status).toBe(200);
      expect(body).toStrictEqual(category);
    });

    it('returns a pet user', async () => {
      const { status, body } = await request(app.getHttpServer()).get(
        `/pets/${pet.id}/user`,
      );

      expect(status).toBe(200);
      expect(body).toStrictEqual(user);
    });
  });

  describe('POST /pets', () => {
    it('creates a pet', async () => {
      const beforeCount = await prisma.pet.count();

      const newPet = {
        name: 'Cat1',
        userId: user.id,
        categoryId: category.id,
        status: 'available',
      };

      const { status, body } = await request(app.getHttpServer())
        .post('/pets')
        .set('Accept', 'application/json')
        .send(newPet);

      const afterCount = await prisma.pet.count();

      expect(status).toBe(201);
      expect(body).toMatchObject(newPet);
      expect(afterCount - beforeCount).toBe(1);
    });
  });

  describe('PUT /pets/:id', () => {
    it('updates a pet', async () => {
      const newOwner = await prisma.user.create({
        data: {
          name: 'Petia Petrov',
          favoriteCategoryId: category.id,
        },
      });

      const updatedPet = {
        name: 'ModifiedTestCat',
        status: pet.status,
        userId: newOwner.id,
        categoryId: pet.categoryId,
      };

      const { status, body } = await request(app.getHttpServer())
        .put(`/pets/${pet.id}`)
        .send(updatedPet);

      const withId = {
        ...updatedPet,
        id: body.id,
      };

      expect(status).toBe(200);
      expect(body).toStrictEqual(withId);
    });
  });

  describe('DELETE /pets/:id', () => {
    it('deletes a pet', async () => {
      const { status } = await request(app.getHttpServer()).delete(
        `/pets/${pet.id}`,
      );

      expect(status).toBe(204);
    });
  });
});
