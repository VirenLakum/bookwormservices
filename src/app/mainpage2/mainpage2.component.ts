import { Component, OnInit } from '@angular/core';
import { ProductserviceService } from '../../services/productservice.service';

import { Product } from "../../poco classes/product";

@Component({
  selector: 'app-mainpage2',
  templateUrl: './mainpage2.component.html',
  styleUrls: ['./mainpage2.component.css']
})
export class Mainpage2Component implements OnInit {

  allProducts : Product[];

  constructor(private productService : ProductserviceService) { }

  ngOnInit() {
    this.loadAllProducts();
  }

  loadAllProducts()
  {
    return this.productService.getallproduct().subscribe( (data)=>{ this.allProducts = data});
  }

}
