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

  username = "";
  isUserLoggedIn = false;

  private prices:number[];
  public checkoutPrice = 0;

  constructor(private cartService:CartService, private productService:ProductserviceService,
    private routes:Router) { }

  ngOnInit() {
    this.username = JSON.parse(localStorage.getItem('user')).name;
    console.log("User name is ", this.username);
    if (this.username == "")
    {
      this.username = "Login";
    }
    else
    {
      this.isUserLoggedIn = true;
    }
    this.getCartItems();
  }

  getCartItems()
  {
    if (this.isUserLoggedIn)
    {
      this.cartService.getallcategory(1).subscribe( (data) => {
        
        this.cartItems = data.filter(this.onlyUnique);
        this.products = new Array(this.cartItems.length);
        this.prices = new Array(this.cartItems.length);
        this.cartItems.forEach( (value, index) =>
        {
          this.prices[index] = 0;
          this.productService.getProductById(value.prod_id).subscribe( (data1)=> {
            this.products[index] = data1;
            this.prices[index] = parseFloat(data1.price);
            if (index == this.cartItems.length-1)
            {
              this.calculateCheckoutPrice();
            }
          });
        });
      });
    }
  }

  onlyUnique(value, index, self) { 
    return self.indexOf(value) === index;
  }


  calculateCheckoutPrice()
  {
    this.checkoutPrice = 0;
    this.prices.forEach( (prod) =>
    {
      console.log(prod);
      this.checkoutPrice += prod;
    });
    console.log(this.checkoutPrice);
  }

  removeItem(p:Product)
  {
    console.log('Removing item:', p);
    debugger;
    this.cartService.removeFromCart(1, p.id).subscribe( (data)=>
     {
       console.log(data);
       if (data.toString() === "true")
       {
          //this.routes.navigateByUrl('/cart');
          window.location.reload();
       }
     });
  }

}
