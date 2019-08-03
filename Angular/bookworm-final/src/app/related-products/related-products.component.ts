import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../../services/productservice.service';
import { Product } from '../../poco classes/product';
import { CartService } from '../../services/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-related-products',
  templateUrl: './related-products.component.html',
  styleUrls: ['./related-products.component.css']
})
export class RelatedProductsComponent implements OnInit {

  products:Product[];
  constructor(private productService:ProductserviceService, private cartService: CartService, private router: Router) { }

  ngOnInit() {
    this.productService.getallproduct().subscribe( (data)=>{ this.products = data;
      this.products.sort(() => Math.random() - 0.5);
    })
  }

  addToCart(p)
  {
    console.log('Add to cart', p);
    this.cartService.addToCart(1,this.products[p].id).subscribe( (data)=>
    {
      console.log(data);
      if (data.toString() === "true")
      {
        this.router.navigateByUrl('cart');
      }
    })
  }

}
