import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { User } from '../poco classes/user';
@Injectable({
  providedIn: 'root'
})
export class RegisterserviceService {
  private adduser='http://localhost:4200';
  private loginurl='http://localhost:4200//ghj';

  constructor(private http:HttpClient) { }

  saveregistration(reg:User): Observable<Object>
  {  console.log(reg);
     return this.http.post(this.adduser,reg);
  }

  loginmethod(reg1:User): Observable<Object>
  {  console.log(reg1);
     return this.http.post(this.loginurl,reg1);
  }
}