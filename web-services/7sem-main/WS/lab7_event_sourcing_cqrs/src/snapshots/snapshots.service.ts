import { Injectable } from '@nestjs/common';

import { PrismaService } from 'src/prisma/prisma.service';

@Injectable()
export class SnapshotsService {
  constructor(private readonly prisma: PrismaService) {}

  async findAll() {
    const snapshots = await this.prisma.snapshot.findMany({
      where: { aggregateType: 'order' },
    });

    return snapshots;
  }

  async findOne(id: string) {
    const snapshot = await this.prisma.snapshot.findFirst({
      where: { id },
    });

    return snapshot;
  }
}
