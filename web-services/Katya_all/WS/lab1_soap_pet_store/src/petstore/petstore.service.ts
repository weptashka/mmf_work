import { Injectable } from '@nestjs/common';

import { PrismaService } from 'src/prisma.service';

import { extractXmlParam, generateXmpResponse } from '../helpers/xml.helpers';

@Injectable()
export class PetStoreService {
  constructor(private prisma: PrismaService) {}

  async getPetById(xmlData): Promise<any> {
    const methodName = 'getPetInfo';
    const responseField = 'petInfo';
    const paramName = 'petId';

    const petId = extractXmlParam(xmlData, methodName, paramName);

    const pet = await this.prisma.pet.findUnique({
      where: { id: petId },
    });

    const xmlPet = generateXmpResponse(pet, methodName, responseField);

    return xmlPet;
  }
}
