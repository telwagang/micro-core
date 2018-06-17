import { LoanService } from './../loan.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loanhome',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'], 
  providers: [LoanService]
})
export class LoanHomeComponent implements OnInit {

  overdue: any;
  pending:any; 
  constructor(private lds:LoanService) { }

  ngOnInit() {
    this.lds.GetPendingAndOverdueItems().then((x:any)=>{
      
        if(x == ''){}
        else{
        this.overdue = x.overdue; 
        this.pending = x.pending; 
        }
      
    }).catch((x)=> console.log(x));
  }


  PayLoan(item:any){

  }
  Account(item:any){

  }
}
