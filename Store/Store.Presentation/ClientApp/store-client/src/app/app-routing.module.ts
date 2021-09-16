import { BooksComponent } from './modules/books/books/books.component';
import { AppComponent } from './app.component';
import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule, Route } from '@angular/router';
import { LayoutComponent } from './modules/layout/layout/layout.component';
import { LayoutModule } from './modules/layout/layout.module';

const routes:Routes=[
  {path:"books",component:BooksComponent}
]

const base: Routes = [
  {path:"home",component:LayoutComponent,children:routes,},
  {path:"",redirectTo:"home/books",pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(base)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
