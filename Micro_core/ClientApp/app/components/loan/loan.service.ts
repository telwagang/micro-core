import { Observable } from 'rxjs/Observable';
import { Loan } from './../../models/loan';
import { Injectable } from "@angular/core";
import { SystemDataService } from "../../services/systemData.service";
import { AppHttpService } from "../../services/apphttp.service";

@Injectable()
export class LoanService {
  url = "loan/";
  constructor(
    private http: AppHttpService,
    private sysdata: SystemDataService
  ) {}

  GetPending() {
    return this.http.get(`${this.url}GetPending/${this.sysdata.getCompany()}`);
  }

  async GetPendingAndOverdueItems(){
    try {
      var items = await this.GetPending().toPromise() as Loan[];
      console.log(items);
      if(items == null) return; 

      var overdue:Loan[] = [];
      var pending:Loan[] = []; 
      var date = new Date().getTime(); 
      items.forEach(element => {
        if(element.dueDate.getTime() >  date){
          overdue.push(element);
        }else{
          pending.push(element);
        }
      });

      return {overdue: overdue,
        pending:pending}; 
    } catch (error) {
      console.log(error); 
      return ("Something went wrong"); 
    }
   
    
  }
}
