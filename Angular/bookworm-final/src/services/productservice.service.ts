import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import {Product } from '../poco classes/product';

@Injectable({
  providedIn: 'root'
})
export class ProductserviceService {
  private baseUrl3='http://localhost:4200';
  private getproducts='http://localhost:55652/Service1.svc/getAllProducts';
  private getProdById = 'http://localhost:55652/Service1.svc/getProductsById/';

  constructor(private http:HttpClient) { }

  addproduct(product:Product): Observable<Object>
  {  console.log(product);
     return this.http.post(this.baseUrl3,product);
  }

  getallproduct():Observable<Product[]>
  {
    console.log("in service");
    return this.http.get<Product[]>(this.getproducts);
  }

  getProductById(id):Observable<Product>
  {
    return this.http.get<Product>(this.getProdById + id);
  }
}
