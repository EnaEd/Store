import { AppRoutingModule } from './../../app-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books/books.component';



@NgModule({
  declarations: [BooksComponent],
  imports: [
    CommonModule
  ]
})
export class BooksModule { }
