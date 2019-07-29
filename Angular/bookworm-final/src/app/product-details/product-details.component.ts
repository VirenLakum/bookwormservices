import { Component, OnInit } from '@angular/core';
import { Product } from '../../poco classes/product';
import { ProductserviceService } from '../../services/productservice.service';
import { CartService } from '../../services/cart.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  private productId:number;

  private product:Product;

  constructor(private productService:ProductserviceService, 
    private cartService:CartService, private router:Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.productId = params.productId;
      this.productService.getProductById(this.productId).subscribe( (prod)=> {
        this.product = prod;
      });
    });
  }

  addToCart(p:Product)
  {
    console.log('Add to cart', p);
    this.cartService.addToCart(1,this.productId).subscribe( (data)=>
    {
      console.log(data);
      if (data.toString() === "true")
      {
        this.router.navigateByUrl('cart');
      }
    })
  }

}
