import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseComponent } from './components/base/base.component';
import { PrintingEditionComponent } from './components/printing-edition/printing-edition.component';
import { SignInComponent } from './components/sign-in/sign-in/sign-in.component';
import { BaseGuard } from './guards/base.guard';

const routes: Routes = [
  {
    path: '',
    component: BaseComponent,
    children: [{ path: '', component: PrintingEditionComponent }],
    canActivate: [BaseGuard],
  },
  { path: 'sign-in', component: SignInComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
