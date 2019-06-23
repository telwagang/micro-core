import { ActiveUser } from './../../models/ActiveUser';
import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';

import { ActivatedRoute, Router } from '@angular/router';
import { UserType } from '../../enum/user-type.enum';
import { SystemDataService } from '../../services/systemData.service';


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
    this.ds.signInWithEmailAndPassword(this.model)
    .subscribe(user=>{
      var activeUser = user.data as ActiveUser; 
    if(activeUser != null)
    {
      this.getuserdetails(activeUser)
      this.loading = false;

    }else{
      console.log(user);
      this.error = user; 
      this.deleteduser = true;
      this.loading = false;
    }});
  
  }

  getuserdetails(value:ActiveUser){
      console.log(value);
      
      var url:any = '';
      
      SystemDataService.prototype.setToken(value.apiKey);
      SystemDataService.prototype.setCompany(value.companyId)
      SystemDataService.prototype.setActiveUser(value);
      SystemDataService.prototype.setStaff(value.typeId);
      switch (+value.type) {
        case UserType.Admin:
        url = 'home';
        break;
        case UserType.Staff:
        url = 'home';
        break;
        case UserType.Customer:
        url = 'home';
        break;
      }
      console.log(url);
      this.router.navigate(['/'+url]);
  }

}
