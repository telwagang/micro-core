import { Akiba } from './../../models/akiba';
import { Injectable } from '@angular/core';
import { AppHttpService } from '../../services/apphttp.service';
import { FormBase } from '../form/formmodel/FormBase';
import { Textbox } from '../form/formmodel/textbox';
import { QuestionBase } from '../form/formmodel/QuestionBase';
import { SystemDataService } from '../../services/systemData.service';

@Injectable()
export class AkibaService {

  private url = 'akiba/'; 
  constructor(private http:AppHttpService,
    private sysdata: SystemDataService) 
  { }

  GetQuestions(): FormBase<any>{
    var customerId = this.sysdata.getCustomer();

    let questions: QuestionBase<any>[] = [

      new Textbox({
        key: 'customerId',
        label: 'Customer Id',
        type: 'string',
        required: true,
        value: customerId,
        order: 1
    }),
      new Textbox({
          key: 'amount',
          label: 'Amount',
          type: 'number',
          required: true,
          order: 2
      }),
      new Textbox({
          key: 'createdDate',
          label: 'Date',
          type: 'date',
          required: false,
          order: 3
      })
    ];
      questions = questions.sort((a, b) => a.order - b.order);

      return new FormBase<any>({
        Id: 0,
        Name: "Transcation Details",
        key: "Id",
        Questions: questions
      })

  }

  getHistory(){
    var companyId = this.sysdata.getCompany(); 

    return this.http.get(`${this.url}GetAkibaHistory/${companyId}`); 
  }

  saveAkiba(acount:Akiba){

    return this.http.post(`${this.url}SetAkiba`, acount); 
  }
}
