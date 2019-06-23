import { Component, OnInit, ChangeDetectorRef, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { AkibaService } from './akiba.service';
import { Akiba } from '../../models/akiba';
import { SystemDataService } from '../../services/systemData.service';
import { AkibaView } from '../../models/akibaView';
import "../../support/functions.js";
import { ThrowStmt } from '@angular/compiler';
import { AkibaType } from '../../enum/akibaType.enum';

@Component({
  selector: 'app-akiba',
  templateUrl: './akiba.component.html',
  styleUrls: ['./akiba.component.css'],
  providers:[AkibaService,SystemDataService]
})
export class AkibaComponent implements OnInit {

  questions: any;
  messeage = '';
  akibaHistory:any; 
  reload= false; 


  constructor(private as: AkibaService,
  private sysdata:SystemDataService,
  private cdRef: ChangeDetectorRef,
  private render: Renderer2) { 
  
  }

  ngOnInit() {
    this.loadHistory();
  }
  
  loadHistory(){
    this.as.getHistory().subscribe(x=>{
      console.log(x);
      this.akibaHistory = x.data; 
    })
  }

  LoadDeposit(){
    this.sysdata.setCustomer("sde21132");
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
     transtion.ctORdt = type;

     if(!transtion.customerId){
       this.messeage = "Fill in customer Id";
       return;
     }
      
     console.log(transtion); 
    
     this.as.saveAkiba(transtion)
     .subscribe(x=> {
       if(x != '') { 
        this.messeage = x;  
        console.log(x);
      } 
     })
   }

   Withdraw(id:any){
     if(id == '') return; 
    this.reload = false; 
    this.sysdata.setCustomer(id); 
    this.sysdata.setTranscationType(AkibaType.Withdraw);
    
    this.BuilderForm();
    this.cdRef.detectChanges();
    this.reload = true; 
   }

   Deposit(id:string){
    if(id == '') return; 
    this.reload = false; 
    this.sysdata.setCustomer(id); 
    this.sysdata.setTranscationType(AkibaType.Deposit);
   
    this.BuilderForm();
    this.cdRef.detectChanges();
    this.reload = true; 
   }
}
