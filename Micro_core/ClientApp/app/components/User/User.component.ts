import { Component, Inject } from '@angular/core';
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
  IsView: boolean;
  error: boolean ; 
  messeage: string;

  searchterm$ = new Subject<string>();

  constructor(private sc: UserService,
    private sysdata: SystemDataService) {

    this.pulltable();
    this.Builderform();
    this.search();

  }

  Builderform() {
    this.questions = this.sc.getQuestions("").subscribe(result => {
      this.questions = result as FormBase<any>;
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
  }

  search(){
      this.sc.search(this.searchterm$)
      .subscribe(result=> {
        this.users = result as User[];
      });
  }
}
