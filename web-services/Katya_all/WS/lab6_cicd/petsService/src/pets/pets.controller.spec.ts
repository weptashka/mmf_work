import { Test } from '@nestjs/testing';
import { PetsController } from './pets.controller';
import { PetsService } from './pets.service';
import { CreatePetDto } from './dto/create-pet.dto';
import { UpdatePetDto } from './dto/update-pet.dto';
import { Pet } from '@prisma/client';

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

describe('Pet Controller', () => {
  let controller: PetsController;

  beforeEach(async () => {
    const module = await Test.createTestingModule({
      controllers: [PetsController],

      providers: [
        {
          provide: PetsService,
          useValue: {
            create: jest
              .fn<Promise<Pet>, [CreatePetDto]>()
              .mockImplementation((pet) =>
                Promise.resolve({ id: pet1Id, ...pet }),
              ),
            findAll: jest
              .fn<Pet[], []>()
              .mockImplementation(() => [pet1, pet2]),
            findOne: jest
              .fn<Promise<Pet>, [string]>()
              .mockImplementation((id) => Promise.resolve({ ...pet1, id })),

            updateOne: jest
              .fn<Promise<Pet>, [string, UpdatePetDto]>()
              .mockImplementation((id, pet) =>
                Promise.resolve({ ...pet1, ...pet, id }),
              ),
            deleteOne: jest
              .fn<{ deleted: boolean }, []>()
              .mockImplementation(() => undefined),
          },
        },
      ],
    }).compile();

    controller = module.get(PetsController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });

  describe('getPets', () => {
    it('should get an array of pets', async () => {
      expect(controller.findAll()).toEqual([pet1, pet2]);
    });
  });
  describe('getById', () => {
    it('should get a single pet', async () => {
      await expect(controller.findOne(pet1Id)).resolves.toEqual(pet1);
    });
  });
  describe('newPet', () => {
    it('should create a new pet', async () => {
      const newPetDTO: CreatePetDto = {
        name: pet1.name,
        categoryId: pet1.categoryId,
        userId: pet1.userId,
        status: pet1.status,
      };

      await expect(controller.create(newPetDTO)).resolves.toEqual({
        id: pet1Id,
        ...newPetDTO,
      });
    });
  });
  describe('updateCat', () => {
    it('should update a pet', async () => {
      const newPetDTO: UpdatePetDto = {
        name: 'New Pet name',
        categoryId: pet1.categoryId,
        userId: pet1.userId,
        status: pet1.status,
      };
      await expect(controller.updateOne(pet1Id, newPetDTO)).resolves.toEqual({
        id: pet1Id,
        ...newPetDTO,
      });
    });
  });
  describe('deleteCat', () => {
    it('should delete a pet', async () => {
      expect(controller.deleteOne(pet1Id)).toEqual(undefined);
    });
  });
});
