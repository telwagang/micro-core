import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { UserType } from '../../enum/user-type.enum';
import { LoginService } from '../login/login.service';
import { SystemDataService } from '../../services/systemData.service';


@Component({
  selector: 'app-login',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  providers:[LoginService]
})
export class SignUpComponent implements OnInit {

    model: any = {};
    loading = false;
   token:string; 
    deleteduser = false; 
    error: string = ''; 

  constructor(
     private ds: LoginService,
     private router: Router,
     private activeRouter : ActivatedRoute ) { 
     this.token = activeRouter.snapshot.paramMap.get("key") || '';
     if(this.token == '')
     this.router.navigate([`/login`]);
     }

  ngOnInit() {
  }

  login() {
    this.loading = true;
    this.deleteduser = false;
    console.log(this.model);

    this.ds.signUpWithUsernameandPassword(this.token, this.model).subscribe
    ((user:any)=>{
     
    if(typeof user == 'string')
    {
      SystemDataService.prototype.setToken(user);

      this.router.navigate([`/home`]);
      this.loading = false;

    }else{
      console.log(user);
      this.error = user; 
      this.deleteduser = true;
      this.loading = false;
    }});
  
  }

  getuserdetails(value:any){
      console.log(value);
      var usertype = value.usertype as UserType;
      console.log(usertype);
      debugger;
      var url:any = '';

      switch (+usertype) {
        case UserType.Admin:
        url = 'home';
        break;
        case UserType.Staff:
        url = 'driver/daily/';
        break;
        case UserType.Customer:
        url = 'tech';
        break;
      }
      console.log(url);
      this.router.navigate(['/'+url]);
  }

}
