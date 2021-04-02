import { BaseGuard } from './guards/base.guard';
import { BaseModule } from './modules/base/base.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, BaseModule],
  providers: [BaseGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
