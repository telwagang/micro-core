import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map, tap, catchError } from 'rxjs/Operators';

import { AppHttpService } from "../../services/apphttp.service";
import { QuestionBase } from '../form/formmodel/questionbase';
import { FormBase } from "../form/formmodel/FormBase";
import { Textbox } from '../form/formmodel/textbox';
import { Interest } from '../../models/interest';
import { Tree } from '@angular/router/src/utils/tree';



@Injectable()
export class InterestService {
  
    private url: string;

    constructor(private http: AppHttpService,
    ) {
        this.url = "setup/";
    }

    getQuestions(id: number): Observable<FormBase<any>> {

        return this.GetInterestWith(id.toString()).pipe(map(result => {
            const value = result.data as Interest;

            const isnot = value == null;
            console.log(value);
            let questions: QuestionBase<any>[] = [

                new Textbox({
                    key: 'duration',
                    label: 'Duration',
                    type: 'number',
                    value: !isnot ? value.duration : '',
                    required: true,
                    order: 1
                }),
                new Textbox({
                    key: 'rate',
                    label: 'Rate',
                    type: 'number',
                    value: !isnot ? value.rate : '',
                    required: true,
                    order: 2
                })
                
            ];

            questions = questions.sort((a, b) => a.order - b.order);

            return new FormBase<any>({
                Id: !isnot ? value.id : 0,
                Name: "Interest Details",
                key: 'id',
                Questions: questions
            })
        }))}

    
        GetInterestWith(id: string) {
        return this.http.get(`${this.url}getinterest/${id}`);
    }

    GetInterest() {
        return this.http.get(`${this.url}getinterest`);
    }

    SetInterest(value:any) {
        return this.http.post(`${this.url}setinterest`, value);
    }
    GetLoanLimit(id:any){
        return this.http.get(`${this.url}loanLimit/${id}`); 
    }

    GetLoanlimit(inte:Interest): FormBase<any>{
            const value = inte;
    
            const isnot = value == null;
            console.log(value);
            let questions: QuestionBase<any>[] = [
    
                new Textbox({
                    key: 'duration',
                    label: 'Duration',
                    type: 'number',
                    value: !isnot ? value.duration : '',
                    required: true,
                    order: 1
                }),
                new Textbox({
                    key: 'rate',
                    label: 'Rate',
                    type: 'number',
                    value: !isnot ? value.rate : '',
                    required: true,
                    order: 2
                }),new Textbox({
                    key: 'limitAmount',
                    label: 'Loan Limit Amount',
                    type: 'number',
                    value: !isnot ? inte.limitAmount : '',
                    required: true,
                    order: 3
                })
                
            ];
    
            questions = questions.sort((a, b) => a.order - b.order);
    
            return new FormBase<any>({
                Id: !isnot ? value.id : 0,
                Name: "Loan Limit Details",
                key: 'id',
                Questions: questions
            })
      }
}