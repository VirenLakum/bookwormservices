import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegisterComponent } from './register/register.component';
import { CarouselComponent } from './carousel/carousel.component';
import { EbookComponent } from './ebook/ebook.component';
import { Mainpage2Component } from './mainpage2/mainpage2.component';
import { HomepageComponent } from './homepage/homepage.component';


import { ReactiveFormsModule } from "@angular/forms";

import {HttpClientModule} from '@angular/common/http';
import { CartComponent } from './cart/cart.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RelatedProductsComponent } from './related-products/related-products.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    CarouselComponent,
    EbookComponent,
    Mainpage2Component,
    HomepageComponent,
    CartComponent,
    ProductDetailsComponent,
    RelatedProductsComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
