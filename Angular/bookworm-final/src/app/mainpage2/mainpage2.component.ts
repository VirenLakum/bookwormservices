import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../../services/productservice.service';
import { CartService } from '../../services/cart.service';

import { Product } from "../../poco classes/product";
import { Cart } from "../../poco classes/cart";
import { User } from '../../poco classes/user';

import { Router } from "@angular/router";

@Component({
  selector: 'app-mainpage2',
  templateUrl: './mainpage2.component.html',
  styleUrls: ['./mainpage2.component.css']
})
export class Mainpage2Component implements OnInit {

  allProducts : Product[];
  cart : Cart[];
  currentUser : User;
  cartCount = 0;

  constructor(private productService : ProductserviceService, private cartService: CartService,
  private  router:Router) { }

  ngOnInit() {
    this.loadAllProducts();
  }

  loadAllProducts()
  {
    return this.productService.getallproduct().subscribe( (data)=>{ this.allProducts = data; this.loadCart()});
  }

  loadCart()
  {
    this.currentUser = JSON.parse(localStorage.getItem('user'));
    console.log(this.currentUser);
    if (true)
    {
      this.cartService.getallcategory(1).subscribe( (data)=> {
        console.log("getting cart", this.currentUser);
        this.cart = data;
        this.cartCount = this.cart.length;
        localStorage.setItem('cartCount', this.cartCount.toString());
      })
    }
  }

  addToCart(p:Product)
  {
    console.log('Add to cart', p);
    this.cartService.addToCart(1,p.id).subscribe( (data)=>
    {
      console.log(data);
      if (data.toString() === "true")
      {
        this.router.navigateByUrl('cart');
      }
    })
  }
}
