import { Injectable } from '@angular/core';
import { ODataServiceFactory } from 'angular-odata';
import { User } from './types';

// Сервис отвечает за хранения текущего пользователя
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private odata: ODataServiceFactory) { }

  createToken(username:string,password:string) {

    let auth = this.odata.entitySet("Auth")
    return auth.entities().q
}
