import { Controller, Get, Param } from '@nestjs/common';
import { SnapshotsService } from './snapshots.service';

@Controller('snapshots')
export class SnapshotsController {
  constructor(private readonly snapshotsService: SnapshotsService) {}

  @Get()
  findAll() {
    return this.snapshotsService.findAll();
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.snapshotsService.findOne(id);
  }
}
