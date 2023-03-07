import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { firstValueFrom, retry, timeout } from 'rxjs';
import { User } from './types';

// Сервис отвечает за хранения текущего пользователя
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  lastUrl: string | null = null

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  private async post(username: string, password: string): Promise<string> {
    return await firstValueFrom(this.http.post(`https://localhost:7020/api/auth`, {username,password},{responseType:'text'})
      .pipe(
        timeout(10000),
        retry(1)
      ));
  }

  private async get(): Promise<User> {
    return await firstValueFrom(this.http.get<User>(`https://localhost:7020/api/auth`)
      .pipe(
        timeout(10000),
        retry(1)
      ));
  }

  public async login(username: string, password: string): Promise<void> {
    let jwt = await this.post(username,password);
    console.log(jwt);
    localStorage.setItem('token',jwt);
    //return await this.get();
  }

  public async get_user(): Promise<User> {
    return await this.get();
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');  
    console.log("токен есть но выдержитесь");
    return !this.jwtHelper.isTokenExpired(token);
  }

}
