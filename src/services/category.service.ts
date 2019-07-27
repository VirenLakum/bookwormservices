import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category} from '../poco classes/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }
  //private getbyid:'http://localhost:4200';
  private getall:'http://localhost:4200';

  // getcategoryById(id:number): Observable<any>
  // {
  //   console.log("hello");
  //   console.log(id);
  //   return this.http.get(this.getbyid + id);
  // }

  getallcategory():Observable<Category[]>
  {
    console.log("in service");
    return this.http.get<Category[]>(this.getall);
  }

  
    
}
