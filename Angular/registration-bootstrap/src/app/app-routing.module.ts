import { AppComponent } from './app.component';
import { EbookComponent } from './ebook/ebook.component';
import { RegisterComponent } from './register/register.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  {
    path : 'a',
    component : RegisterComponent
  },

  {
    path : 'b',
    component : EbookComponent
  },

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
