import { Controller, Post, Body } from '@nestjs/common';
import { PetStoreService } from './petstore.service';

@Controller('petStore')
export class PetStoreController {
  constructor(private readonly petStoreService: PetStoreService) {}

  @Post()
  async getPetById(@Body() xmlData): Promise<any> {
    return this.petStoreService.getPetById(xmlData);
  }
}
