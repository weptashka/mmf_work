import { Test, TestingModule } from '@nestjs/testing';
import { PrismaService } from '../prisma/prisma.service';
import { PetsService } from './pets.service';

const pet1Id = '64f31872fc13ae3f0ead21e6';

const pet1 = {
  id: pet1Id,
  name: 'Allie',
  status: 'pending',
  categoryId: '6574242969c4f647f4d9f13c',
  userId: '657422c669c4f647f4d9f13a',
};

const pet2 = {
  id: '64f31872fc13ae3f0ead21e3',
  name: 'Arlana',
  status: 'sold',
  categoryId: '6574242969c4f647f4d9f13c',
  userId: '657422c669c4f647f4d9f13a',
};

const petsArray = [pet1, pet2];

const db = {
  pet: {
    findMany: jest.fn().mockResolvedValue(petsArray),
    findUnique: jest.fn().mockResolvedValue(pet1),
    findFirst: jest.fn().mockResolvedValue(pet1),
    create: jest.fn().mockReturnValue(pet1),
    save: jest.fn(),
    update: jest.fn().mockResolvedValue(pet1),
    delete: jest.fn().mockResolvedValue(pet1),
  },
};

describe('PetService', () => {
  let service: PetsService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [
        PetsService,
        {
          provide: PrismaService,
          useValue: db,
        },
      ],
    }).compile();

    service = module.get<PetsService>(PetsService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });

  describe('getAll', () => {
    it('should return an array of pets', async () => {
      const cats = await service.findAll();
      expect(cats).toEqual(petsArray);
    });
  });

  describe('getOne', () => {
    it('should get a single cat', () => {
      expect(service.findOne('a uuid')).resolves.toEqual(pet1);
    });
  });

  describe('insertOne', () => {
    it('should successfully insert a cat', () => {
      expect(service.create(pet1)).resolves.toEqual(pet1);
    });
  });

  describe('updateOne', () => {
    it('should call the update method', async () => {
      expect(service.updateOne(pet1Id, pet1)).resolves.toEqual(pet1);
    });
  });

  describe('deleteOne', () => {
    it('should return {deleted: true}', () => {
      expect(service.deleteOne('a uuid')).resolves.toEqual(undefined);
    });
  });
});
