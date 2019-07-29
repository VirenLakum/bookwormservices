import { Component, OnInit } from '@angular/core';

import { Cart } from "../../poco classes/cart";
import { Product } from "../../poco classes/product";

import { CartService } from "../../services/cart.service";
import { ProductserviceService } from "../../services/productservice.service";

import { Router } from "@angular/router";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems : Cart[];
  products : Product[];

  public checkoutPrice = 0;

  constructor(private cartService:CartService, private productService:ProductserviceService,
    private routes:Router) { }

  ngOnInit() {
    this.getCartItems();
  }

  getCartItems()
  {
    this.cartService.getallcategory(1).subscribe( (data) => {
      this.cartItems = data;
      this.products = new Array(this.cartItems.length);
      this.cartItems.forEach( (value, index) =>
      {
        this.productService.getProductById(value.prod_id).subscribe( (data1)=> {
          this.products[index] = data1;
          if (index == this.cartItems.length-1)
          {
            this.calculateCheckoutPrice();
          }
        });
      });
    });
  }

  calculateCheckoutPrice()
  {
    this.products.forEach( (prod) =>
    {
      console.log(prod);
      this.checkoutPrice += parseFloat(prod.price);
    });
    console.log(this.checkoutPrice);
  }

  removeItem(p:Product)
  {
    console.log('Removing item:', p);
    this.cartService.removeFromCart(1, p.id).subscribe( (data)=>
     {
       console.log(data);
       if (data.toString() === "true")
       {
          this.routes.navigateByUrl('/cart');
          window.location.reload();
       }
     });
  }

}
