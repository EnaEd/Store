import { AccountState } from './../../store/states/account-state/account.state';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxsModule } from '@ngxs/store';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgxsModule.forRoot([AccountState], {
      developmentMode: !environment.production,
    }),
  ],
})
export class StateModule {}
