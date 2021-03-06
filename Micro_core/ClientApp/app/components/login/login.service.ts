import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppHttpService } from '../../services/apphttp.service';
import { SystemDataService } from '../../services/systemData.service';

@Injectable()
export class LoginService {

  
  
  private url : string; 
  constructor(private db: AppHttpService) { 
   this.url = "Auth/";
  }

  
  signInWithEmailAndPassword(value:any) {
    return this.db.post(this.url+"login",value );
  }
  
   checkToken(value:any){
     return this.db.get(`${this.url}VerifyKey/${value}`);
   }
   signUpWithUsernameandPassword(arg0: any, arg1: any): any {
    arg1.apiKey = arg0; 
    console.log(arg1);
    return this.db.post(`${this.url}signup`, arg1); 
  }
  CheckToken(){
    var token = SystemDataService.prototype.getToken();
    return this.db.get(`${this.url}VerifyToken/${token}`);
  }
}
