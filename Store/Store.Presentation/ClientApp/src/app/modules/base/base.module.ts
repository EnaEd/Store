import { FooterComponent } from './../../components/footer/footer.component';
import { AccountModule } from './../account/account.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseComponent } from 'src/app/components/base/base.component';
import { HeaderComponent } from 'src/app/components/header/header.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { PrintingEditionModule } from '../printing-edition/printing-edition.module';

@NgModule({
  declarations: [BaseComponent, HeaderComponent, FooterComponent],
  imports: [
    CommonModule,
    AccountModule,
    PrintingEditionModule,
    AppRoutingModule,
  ],
})
export class BaseModule {}
