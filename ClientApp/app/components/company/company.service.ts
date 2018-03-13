import { Injectable,Inject } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map,tap, catchError } from 'rxjs/Operators';

import { Dropdown } from '../form/formmodel/dropdown';
import { QuestionBase } from '../form/formmodel/questionbase';
import { FormBase } from "../form/formmodel/FormBase";
import { Textbox } from '../form/formmodel/textbox';
import { inject } from '@angular/core/testing';
import { Company } from "../../models/company";
import { FormGroup } from '@angular/forms/src/model';
import { SystemDataService } from '../../services/systemData.service';

@Injectable()
export class CompanyService {
   public url:string;
   
    httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
    constructor(private http: HttpClient,
    @Inject('BASE_URL') orginurl:string,
      private sysdata: SystemDataService){
        this.url = orginurl + "api/setup"; 
    }
  // Todo: get from a remote source of question metadata
  // Todo: make asynchronous
  getQuestions() :Observable<FormBase<any>> {
    
    return this.GetCompany().pipe(map(result =>
    {
      const value = result as Company; 
      
      const isnot = value == null; 
      console.log(value);

      this.sysdata.setCompany(value.companyId);

      let questions : QuestionBase<any>[] = [

        new Textbox({
            key: 'Tin_no',
            label: 'Tin Number',
            type: 'number',
            value: !isnot ? value.tin_no : '',
            required: false,
            order: 1
          }),
      new Textbox({
        key: 'Name',
        label: 'Company Name',
        type: 'text',
        value: !isnot ? value.name : '',
        required: true,
        order: 2
      }),
      new Textbox({
        key: 'Location',
        label: 'Location',
        type: 'text',
        value: !isnot ? value.location : '' ,
        required: false,
        order: 3
      }),
      new Textbox({
        key: 'Address',
        label: 'Address',
        type: 'text',
        value: !isnot ? value.address : '',
        required: true,
        order: 4
      }),
      new Textbox({
        key: 'MobileNumber',
        label: 'Mobile Number',
        type: 'mobile',
        value: !isnot ? value.mobileNumber : '',
        required: false,
        order: 5
      }),
      new Textbox({
        key: 'Date',
        label: 'Start Date',
        type: 'date',
        value:!isnot ? new Date(value.date) : '',
        required: true,
        order: 7
      }),
      new Textbox({
        key: 'Email',
        label: 'Email',
        type: 'email',
        value: !isnot ? value.email : '',
        required: true,
        order: 6
      })
    ];

    questions =  questions.sort((a, b) => a.order - b.order);
  
     return new FormBase<any>({
        Id:!isnot ? value.companyId : 0,
        Name : "Company Details",
        key: 'companyId',
        Questions:questions
    })
  }))

    
  }

  setCompany(value:string){
    
     return this.http.post(this.url+'/setcompany', value, this.httpOptions)
      .pipe(catchError(this.handleError<any>("Add Company")))
      ;
  }

  GetCompany(){
      return this.http.get(this.url+'/getcompany', this.httpOptions)
      .pipe(tap(h => {
        const outcome = h ? `fetched` : `did not find`;
        this.log(`${outcome}`);
      }),
      catchError(this.handleError<any>("get Company")));
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
 
  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    //this.messageService.add('HeroService: ' + message);
    console.log(message);
  }
}

