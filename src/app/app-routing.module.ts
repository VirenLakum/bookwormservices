// import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EbookComponent } from './ebook/ebook.component';
import { RegisterComponent } from './register/register.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';



const routes: Routes = [
  {
    path : '',
    component : HomepageComponent
  },

  {
    path : 'register',
    component : RegisterComponent
  }

  // {
  //   path : '**',
  //   component : AppComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
// export const routingComponent = [RegisterComponent,EbookComponent]
