import { HttpService } from '@nestjs/axios';
import { Injectable } from '@nestjs/common';
import { AxiosError } from 'axios';
import { catchError, firstValueFrom } from 'rxjs';

@Injectable()
export class AuthService {
  constructor(private readonly httpService: HttpService) {}

  async google(accessToken: string) {
    const { data: userData } = await firstValueFrom(
      this.httpService
        .get('https://www.googleapis.com/oauth2/v1/userinfo?alt=json', {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .pipe(
          catchError((error: AxiosError) => {
            console.log(error);
            throw 'An error happened!';
          }),
        ),
    );

    return userData;
  }

  async githubAuth(code: string) {
    console.log(code);

    const { data } = await firstValueFrom(
      this.httpService
        .post('https://github.com/login/oauth/access_token', {
          client_id: process.env.GITHUB_CLIENT_ID,
          client_secret: process.env.GITHUB_CLIENT_SECRET,
          code,
          redirect_uri: 'http://localhost:3001/auth/github',
        })
        .pipe(
          catchError((error: AxiosError) => {
            console.log(error.response.data);
            throw 'An error happened!';
          }),
        ),
    );

    const parsedData = new URLSearchParams(data);
    const accessToken = parsedData.get('access_token');

    const { data: userData } = await firstValueFrom(
      this.httpService
        .get('https://api.github.com/user', {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .pipe(
          catchError((error: AxiosError) => {
            console.log(error);
            console.log(error.response.data);
            throw 'An error happened!';
          }),
        ),
    );

    return userData;
  }

  async discordAuth(code: string) {
    const { data } = await firstValueFrom(
      this.httpService
        .post(
          'https://discord.com/api/v10/oauth2/token',
          {
            client_id: process.env.DISCORD_CLIENT_ID,
            client_secret: process.env.DISCORD_CLIENT_SECRET,
            grant_type: 'authorization_code',
            code,
            redirect_uri: 'http://localhost:3001/auth/discord',
          },
          {
            headers: {
              'Content-Type': 'application/x-www-form-urlencoded',
            },
          },
        )
        .pipe(
          catchError((error: AxiosError) => {
            console.log(error);
            console.log(error.response.data);
            throw 'An error happened!';
          }),
        ),
    );
    const parsedData = new URLSearchParams(data);
    const accessToken = parsedData.get('access_token');

    const { data: userData } = await firstValueFrom(
      this.httpService
        .get('https://discord.com/api/v10/users/@me', {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .pipe(
          catchError((error: AxiosError) => {
            console.log(error);
            console.log(error.response.data);
            throw 'An error happened!';
          }),
        ),
    );

    return { userData };
  }
}
