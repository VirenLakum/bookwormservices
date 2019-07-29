// import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EbookComponent } from './ebook/ebook.component';
import { RegisterComponent } from './register/register.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { CartComponent } from "./cart/cart.component";
import { ProductDetailsComponent } from './product-details/product-details.component';



const routes: Routes = [
  {
    path : '',
    component : HomepageComponent
  },

  {
    path : 'register',
    component : RegisterComponent
  },
  {
    path : 'cart',
    component : CartComponent
  },
  {
    path : 'productDetails/:productId',
    component : ProductDetailsComponent
  }

  // {
  //   path : '**',
  //   component : AppComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
// export const routingComponent = [RegisterComponent,EbookComponent]
