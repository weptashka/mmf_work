import { Controller, Get, Query, Res } from '@nestjs/common';
import { AuthService } from './auth.service';

@Controller('auth')
export class AuthController {
  constructor(private readonly authService: AuthService) {}

  @Get('/google')
  async google(@Query('access_token') accessToken: string) {
    const { name } = await this.authService.google(accessToken);

    return { username: name };
  }

  @Get('/github')
  async github(@Res() res, @Query('code') code: string) {
    const { login } = await this.authService.githubAuth(code);

    res.status(302).redirect(`${process.env.WEB_URL}?username=${login}#auth`);
  }

  @Get('/discord')
  async discord(@Res() res, @Query('code') code: string) {
    const {
      userData: { username },
    } = await this.authService.discordAuth(code);

    res
      .status(302)
      .redirect(`${process.env.WEB_URL}?username=${username}#auth`);
  }
}
