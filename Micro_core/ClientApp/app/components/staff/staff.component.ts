import { Component, OnInit } from '@angular/core';

import { FormBase } from "../form/formmodel/FormBase";
import { StaffService } from "./staff.service";
import { Staff } from "../../models/staff";
import { SystemDataService } from "../../services/systemData.service";
@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css'],
  providers: [StaffService,SystemDataService]
})
export class StaffComponent implements OnInit {

  error: boolean;
  questions: any;
  messege: string;
  staffs: Staff[] = [];

  constructor(private ss: StaffService,
    private sysdata: SystemDataService
  ) {
    this.refreshTable();
    this.EditStaff(0);
  }

  ngOnInit() {
  }

  EditStaff(id: any) {
    this.ss.getQuestions(id)
      .subscribe(result => {
      this.questions = result as FormBase<any>;
        console.log(this.questions);
        this.error = false;
      });
  }
refreshTable(){
  this.ss.GetStaff()
      .subscribe(result => { 
        this.staffs = result as Staff[];
        console.log(result); 
      });
}
  delete(id: any) {

  }
  save(value: any) {
    var staff = JSON.parse(value) as Staff;
    var companyid = this.sysdata.getCompany();
    
    if (!companyid) {
      this.messege = "company Id not found, fill company data first";
      this.error = true;
      return;
    }
    
    staff.companyId = parseInt(companyid); 
    staff.id = staff.id ? staff.id : 0;

    this.ss.SetStaff(JSON.stringify(staff))
      .subscribe(result => {
        this.refreshTable();
      });

  }
}
