import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cart } from '../poco classes/cart';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }
  private getCart = 'http://localhost:55652/Service1.svc/getCartDetailsFor/';

  private removeItem = 'http://localhost:55652/Service1.svc/removeFromCart/';

  private addItem = 'http://localhost:55652/Service1.svc/addToCart/';

  getallcategory(userId):Observable<Cart[]>
  {
    console.log(this.getCart + (userId.toString()));
    return this.http.get<Cart[]>(this.getCart+userId);
  }

  removeFromCart(userId, prodId)
  {
    //debugger;
    return this.http.get<string>(this.removeItem + userId + '/' + prodId);
  }

  addToCart(userId, prodId)
  {
    return this.http.get<string>(this.addItem + userId + '/' + prodId);
  }

}
