import { AccountModule } from './../account/account.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseComponent } from 'src/app/components/base/base.component';
import { HeaderComponent } from 'src/app/components/header/header.component';
import { FooterComponent } from 'src/app/components/footer/footer.component';

@NgModule({
  declarations: [BaseComponent, HeaderComponent, FooterComponent],
  imports: [CommonModule, AccountModule],
})
export class BaseModule {}
