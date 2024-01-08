import { Injectable } from '@nestjs/common';
import { CreateEventDto } from './dto/create-event.dto';
import { PrismaService } from 'src/prisma/prisma.service';
import { SearchEventDto } from './dto/search-event.dto';

@Injectable()
export class EventsService {
  constructor(private prisma: PrismaService) {
    const TREE_MONTH_IN_SECONDS = 90 * 24 * 60 * 60;

    (async () => {
      await this.prisma.$runCommandRaw({
        createIndexes: 'Event',
        indexes: [
          {
            key: {
              createdAt: 1,
            },
            name: 'createdAt_ttl_index',
            expireAfterSeconds: TREE_MONTH_IN_SECONDS,
          },
        ],
      });
    })();
  }

  async create(createEventDto: CreateEventDto) {
    const event = await this.prisma.event.create({
      data: createEventDto as any,
    });

    return event;
  }

  async createByJsonFile(file: any) {
    const fileSting = file.buffer.toString();
    const events = await this.prisma.event.createMany({
      data: JSON.parse(fileSting) as any,
    });

    return { status: 'ok', recordedCount: events.count };
  }

  async findAll() {
    const events = await this.prisma.event.findMany();

    return events;
  }

  async findOne(id: string) {
    const event = await this.prisma.event.findUnique({
      where: { id },
    });

    return event;
  }

  async searchAll(query: SearchEventDto) {
    const { createdAtFrom, createdAtTo, ...rest } = query;
    const result = await this.prisma.event.findRaw({
      filter: rest as any,
    });

    const dateRange = (result as any).filter(({ createdAt }) => {
      return (
        (createdAtFrom ? createdAtFrom < createdAt['$date'] : true) &&
        (createdAtTo ? createdAt['$date'] < createdAtTo : true)
      );
    });

    return dateRange;
  }

  async getStatusStats() {
    const result = await this.prisma.event.groupBy({
      by: ['status'],
      _count: true,
    });

    return result;
  }

  async getServiceStats() {
    const result = await this.prisma.event.groupBy({
      by: ['service'],
      _count: true,
    });

    return result;
  }

  async getSourceStats() {
    const result = await this.prisma.event.groupBy({
      by: ['source'],
      _count: true,
    });

    return result;
  }

  async getDateRangeFrequencyStats() {
    function dateFromString(dateField) {
      // Slice date [2021-01-25]T11:58:32.000Z from datetime string
      return { dateString: { $substr: [`$${dateField}`, 0, 10] } };
    }

    const result = await this.prisma.event.aggregateRaw({
      pipeline: [
        {
          $project: {
            date: { $dateFromString: dateFromString('createdAt') },
          },
        },
        { $group: { _id: '$date', count: { $sum: 1 } } },
        { $project: { date: '$_id', count: 1, _id: 0 } },
      ],
    });

    return result;
  }
}
