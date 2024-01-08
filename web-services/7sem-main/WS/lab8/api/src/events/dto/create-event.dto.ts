import { Event } from '@prisma/client';

import { PartialType } from '@nestjs/mapped-types';

export class CreateEventDto extends PartialType(Event) {}
