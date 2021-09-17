import { AppRoutingModule } from './../../app-routing.module';
import { BooksModule } from './../books/books.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  declarations: [LayoutComponent],
  imports: [CommonModule, BooksModule, AppRoutingModule],
})
export class LayoutModule {}
