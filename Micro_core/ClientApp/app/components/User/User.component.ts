import { Component, Inject, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { User } from "../../models/user";
import { UserService } from "./User.Service";
import { SystemDataService } from '../../services/systemData.service';
import { FormBase } from '../form/formmodel/FormBase';
import { Subject } from 'rxjs/Subject';

@Component({
  selector: 'app-User',
  templateUrl: './User.component.html',
  styleUrls: ['./User.component.css'],
  providers: [UserService, SystemDataService]
})
export class UserComponent {

  public users: User[] = [];
  questions: any;
  private user: User;
  IsView = false; 
  error: boolean = false; 
  messeage: string = '';

  searchterm$ = new Subject<string>();

  constructor(private sc: UserService,
    private sysdata: SystemDataService,
    private cdRef: ChangeDetectorRef) {

    this.pulltable();
    //this.Builderform();
    this.search();

  }

  Builderform(id = "") {
    this.sc.getQuestions(id).subscribe(result => {
      this.questions = result as FormBase<any>;
      this.cdRef.detectChanges();
      this.isAdd();
    });
  }

  pulltable() {
    this.sc.GetCustomer().subscribe(
      result => {
        this.users = result as User[];
      
      }
    )
  }

  save(value: any) {
    var customer = JSON.parse(value) as User;
    var company = this.sysdata.getCompany();
    var staffid = this.sysdata.getStaff();

    if (!staffid) {
      this.messeage = "Staff id is missing from system. reload staff details ";
      this.error = true;
      return;

    }

    customer.customerId = customer.customerId ? customer.customerId : "";
    customer.staffId = parseInt(staffid);

    this.sc.SetCustomer(JSON.stringify(customer)).subscribe(res => {
      this.pulltable();
    })
  }

  isAdd() {
    this.IsView = !this.IsView;
    //this.Builderform(""); 
  }

  search(){
      this.sc.search(this.searchterm$)
      .subscribe(result=> {
        this.users = result as User[];
      });
  }
  EditStaff(id:any){
    this.IsView = false; 
     this.Builderform(id); 
     
  }
  AddNew(){
    this.IsView = false;  
    this.Builderform(""); 
    
  }

  Account(id:any){

  }

  Delete(id:any){

  }
  CloseModel(){
   this.IsView = false; 
  }
}
