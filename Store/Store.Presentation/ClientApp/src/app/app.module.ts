import { HttpService } from './services/http-service';
import { StateModule } from './modules/state/state.module';
import { BaseGuard } from './guards/base.guard';
import { BaseModule } from './modules/base/base.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, BaseModule, StateModule],
  providers: [BaseGuard, HttpService],
  bootstrap: [AppComponent],
})
export class AppModule {}
