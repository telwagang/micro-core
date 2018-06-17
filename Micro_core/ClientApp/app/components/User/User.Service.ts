import { Injectable } from '@angular/core';

import { Dropdown } from '../form/formmodel/dropdown';
import { QuestionBase } from '../form/formmodel/questionbase';
import { FormBase } from "../form/formmodel/FormBase";
import { Textbox } from '../form/formmodel/textbox';
import { AppHttpService } from '../../services/apphttp.service';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/Operators/map';
import { debounceTime , distinctUntilChanged} from "rxjs/Operators";
import { User } from '../../models/user';
import { Subject, } from 'rxjs/Subject';
import { switchMap } from 'rxjs/Operators/switchMap';

@Injectable()
export class UserService {

  public url: string;

  constructor(public http: AppHttpService) {
    this.url = "user/";
  }
  // Todo: get from a remote source of question metadata
  // Todo: make asynchronous
  getQuestions(id: string): Observable<FormBase<any>> {

    return this.GetCustomerWith(id).pipe(map(
      result => {
        const value = result as User;
        const isnot = value == null;
        console.log(result);
        let questions: QuestionBase<any>[] = [

          new Textbox({
            key: 'national_id',
            label: 'National Id',
            type: 'number',
            required: false,
            value: !isnot ?
              value.national_id : '',
            order: 1
          }),
          new Textbox({
            key: 'first_Name',
            label: 'First Name',
            type: 'text',
            required: true,
            value: !isnot ?
              value.first_Name : '',
            order: 2
          }),
          new Textbox({
            key: 'middle_Name',
            label: 'Middle Name',
            type: 'text',
            required: false,
            value: !isnot ?
              value.middle_Name : '',
            order: 3
          }),
          new Textbox({
            key: 'last_Name',
            label: 'Last Name',
            type: 'text',
            required: true,
            value: !isnot ?
              value.last_Name : '',
            order: 4
          }),
          new Textbox({
            key: 'mobile_Number',
            label: 'Mobile Number',
            type: 'mobile',
            required: false,
            value: !isnot ?
              value.mobile_Number : '',
            order: 5
          }),
          new Textbox({
            key: 'birthdate',
            label: 'Birth Date',
            type: 'date',
            required: true,
            value: !isnot ?
              value.birthdate : '',
            order: 6
          }),
          new Textbox({
            key: 'email',
            label: 'Email',
            type: 'email',
            required: true,
            value: !isnot ?
              value.email : '',
            order: 8
          }),
          new Textbox({
            key: 'occupation',
            label: 'Occupation',
            type: 'text',
            required: false,
            value: !isnot ?
              value.occupation : '',
            order: 7
          }),
          new Textbox({
            key: 'address',
            label: 'Address',
            type: 'text',
            required: false,
            value: !isnot ?
              value.address : '',
            order: 9
          })
        ];

        questions = questions.sort((a, b) => a.order - b.order);

        return new FormBase<any>({
          Id: !isnot ?
            value.customerId : "",
          key: "customerId",
          Name: "Customer Details",
          Questions: questions
        })
      }))
  }

  GetCustomerWith(id: string) {
    return this.http.get(`${this.url}getcustomers/${id}`);
  }

  GetCustomer() {
    return this.http.get(`${this.url}getcustomers`);
  }

  SetCustomer(value: any) {
    return this.http.post(`${this.url}setcustomer`, value);
  }
 search(name:Observable<string>){
    return name.pipe(debounceTime(500),
    distinctUntilChanged(),
    switchMap(t=> this.find(t)));
 }
 private find(t:any){
   console.log(t);
  return this.http.get(`${this.url}searchcustomer/${t}`);
 }
}

