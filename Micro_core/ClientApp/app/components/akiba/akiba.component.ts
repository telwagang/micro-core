import { Component, OnInit } from '@angular/core';
import { AkibaService } from './akiba.service';
import { Akiba } from '../../models/akiba';
import { SystemDataService } from '../../services/systemData.service';
import { AkibaView } from '../../models/akibaView';
import "../../support/functions.js";

declare var BoostrapFunctions:any; 
declare var webGlObject: any;

@Component({
  selector: 'app-akiba',
  templateUrl: './akiba.component.html',
  styleUrls: ['./akiba.component.css'],
  providers:[AkibaService,SystemDataService]
})
export class AkibaComponent implements OnInit {

  questions: any;
  messeage:string;

  constructor(private as: AkibaService,
  private sysdata:SystemDataService) { 
  
  }

  ngOnInit() {
    
  }

  LoadDeposit(){
    this.sysdata.setCustomer("sde21132");//view.customer.customerId); 
   BoostrapFunctions.triggerModal();
    //$("div");
    this.BuilderForm();
  }
  
   BuilderForm(){
    this.questions = this.as.GetQuestions();
   }

   save(value:any){
     var transtion = JSON.parse(value) as Akiba;
     
     var staffid = parseInt(this.sysdata.getStaff()); 
     var type = this.sysdata.getTranscationType();

     transtion.staffId = staffid;
     transtion.transcationType = type;

     if(!transtion.customerId){
       this.messeage = "Fill in customer Id";
       return;
     }

     console.log(transtion); 

   }


}
