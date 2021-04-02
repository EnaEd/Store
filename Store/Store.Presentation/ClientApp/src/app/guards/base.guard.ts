import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class BaseGuard implements CanActivate {
  constructor(private _router: Router) {}
  canActivate(): boolean {
    this._router.navigateByUrl('/sign-in');
    return false;
  }
}
