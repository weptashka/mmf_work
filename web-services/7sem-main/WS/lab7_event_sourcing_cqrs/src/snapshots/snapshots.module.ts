import { Global, Module } from '@nestjs/common';

import { SnapshotsController } from './snapshots.controller';
import { SnapshotsService } from './snapshots.service';

@Global()
@Module({
  controllers: [SnapshotsController],
  providers: [SnapshotsService],
})
export class SnapshotsModule {}
