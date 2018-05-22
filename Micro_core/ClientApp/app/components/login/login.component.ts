import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';

import { ActivatedRoute, Router } from '@angular/router';
import { UserType } from '../../enum/user-type.enum';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[LoginService]
})
export class LoginComponent implements OnInit {

    model: any = {};
    loading = false;
   
    deleteduser = false; 
    error: string = ''; 

  constructor(
     private ds: LoginService,
     private router: Router ) { }

  ngOnInit() {
  }

  login() {
    this.loading = true;
    this.deleteduser = false;
    console.log(this.model);
    this.ds.signInWithEmailAndPassword(this.model).subscribe
    (user=>{
      console.log(user);
    if(typeof user == 'number')
    {
      this.getuserdetails(user)
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
