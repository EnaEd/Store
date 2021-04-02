import { AccountService } from './../../services/account-service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInComponent } from 'src/app/components/sign-in/sign-in/sign-in.component';

@NgModule({
  declarations: [SignInComponent],
  imports: [CommonModule],
  providers: [AccountService],
})
export class AccountModule {}
