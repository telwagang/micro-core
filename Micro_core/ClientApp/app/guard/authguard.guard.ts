import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { LoginService } from '../components/login/login.service';

@Injectable()
export class AuthguardGuard implements CanActivate {


  constructor(private router: Router,
  private ls: LoginService){

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot){
    

      return new Observable<boolean>(n=>{
        
        this.ls.checkToken(next.params['key']).subscribe(d => {
          if (d) {
            
            n.next(true);
          } else {
            // not logged in so redirect to login page with the return url
          this.router.navigate(['/login']);
          n.next( false);
          }
        });
      })
    
  }
}
