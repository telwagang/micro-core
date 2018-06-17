import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBase } from '../form/formmodel/FormBase';
import { SystemDataService } from '../../services/systemData.service';
import { Interest } from '../../models/interest';
import { InterestService } from './interest.service';

@Component({
  selector: 'app-interest',
  templateUrl: './interest.component.html',
  styleUrls: ['./interest.component.css'],
  providers:[InterestService, SystemDataService]
})
export class InterestComponent implements OnInit {

 
  error: boolean;
  questions: any;
  messege: string;
  staffs: Interest[] = [];
  reload = false; 
 loanLimit:any; 

  constructor(private ss: InterestService,
    private sysdata: SystemDataService,
    private cdRef: ChangeDetectorRef
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
  this.ss.GetInterest()
      .subscribe(result => { 
        this.staffs = result as Interest[];
        console.log(result); 
      });
}
  delete(id: any) {

  }
  save(value: any) {
    var staff = JSON.parse(value) as Interest;
    var companyid = this.sysdata.getCompany();
    
    if (!companyid) {
      this.messege = "company Id not found, fill company data first";
      this.error = true;
      return;
    }
    
    staff.companyId = parseInt(companyid);
    staff.staffId = parseInt(this.sysdata.getStaff());  
    staff.id = staff.id ? staff.id : 0;

    this.ss.SetInterest(JSON.stringify(staff))
      .subscribe(result => {
        this.refreshTable();
      });

  }
  SaveLoanLimit(value:any){
    let lm = this.sysdata.getTempeId() as Interest; 
    var staff = JSON.parse(value) as Interest;
    lm.limitAmount = staff.limitAmount;

   this.ss.SetInterest(JSON.stringify(lm))
    .subscribe(result => {
      this.refreshTable();
    });
  }

  AddLoanLimit(id:Interest){
    try {
      if(id == null) return; 
      this.reload = false; 
      this.sysdata.setTempeId(id);
      this.loanLimit = this.ss.GetLoanlimit(id);
        this.cdRef.detectChanges();
        this.reload = true;
       
    } catch (error) {
      this.sysdata.setTempeId(""); 
    }

  }

}
