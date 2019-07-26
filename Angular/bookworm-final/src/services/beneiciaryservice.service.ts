import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { Beneficiary } from '../poco classes/beneficiary';

@Injectable({
  providedIn: 'root'
})
export class BeneiciaryserviceService {

private baseurl4='http://localhost:4200';

  constructor(private http: HttpClient) { }

  savebeneficiary(benf:Beneficiary):Observable<Object>
{
  console.log(benf);
  return this.http.post(this.baseurl4,benf);
}
}

