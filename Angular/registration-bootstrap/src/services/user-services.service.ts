import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import {Observable} from 'rxjs';
import { User } from "../poco classes/user";

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {

  private addUserUrl='http://localhost:55652/Service1.svc/addUser';

  constructor(private http:HttpClient) { }

  public saveregistration(user:User): Observable<Object>
  {
    console.log(user);
    return this.http.post(this.addUserUrl, user);
  }
}
