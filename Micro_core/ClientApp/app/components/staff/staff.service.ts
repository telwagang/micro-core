import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map, tap, catchError } from 'rxjs/Operators';

import { AppHttpService } from "../../services/apphttp.service";
import { QuestionBase } from '../form/formmodel/questionbase';
import { FormBase } from "../form/formmodel/FormBase";
import { Textbox } from '../form/formmodel/textbox';
import { Staff } from "../../models/staff";



@Injectable()
export class StaffService {
    public url: string;

    constructor(private http: AppHttpService,
    ) {
        this.url = "setup/";
    }

    getQuestions(id: number): Observable<FormBase<any>> {

        return this.GetStaffWith(id.toString()).pipe(map(result => {
            const value = result.data as Staff;

            const isnot = value == null;
            console.log(value);
            let questions: QuestionBase<any>[] = [

                new Textbox({
                    key: 'first_Name',
                    label: 'First Name',
                    type: 'text',
                    value: !isnot ? value.first_Name : '',
                    required: true,
                    order: 2
                }),
                new Textbox({
                    key: 'middle_Name',
                    label: 'Middle Name',
                    type: 'text',
                    value: !isnot ? value.middle_Name : '',
                    required: false,
                    order: 3
                }),
                new Textbox({
                    key: 'last_Name',
                    label: 'Last Name',
                    type: 'text',
                    value: !isnot ? value.last_Name : '',
                    required: true,
                    order: 4
                }),
                new Textbox({
                    key: 'position',
                    label: 'Position',
                    type: 'text',
                    value: !isnot ? value.position : '',
                    required: true,
                    order: 4
                }),
                new Textbox({
                    key: 'mobile_Number',
                    label: 'Mobile Number',
                    type: 'mobile',
                    value: !isnot ? value.mobile_Number : '',
                    required: false,
                    order: 5
                }),
                new Textbox({
                    key: 'birthdate',
                    label: 'Birth Date',
                    type: 'date',
                    value: !isnot ? new Date(value.birthdate) : '',
                    required: true,
                    order: 7
                }),
                new Textbox({
                    key: 'email',
                    label: 'Email',
                    type: 'email',
                    value: !isnot ? value.email : '',
                    required: true,
                    order: 6
                })
            ];

            questions = questions.sort((a, b) => a.order - b.order);

            return new FormBase<any>({
                Id: !isnot ? value.id : 0,
                Name: "Staff Details",
                key: 'id',
                Questions: questions
            })
        }))
    }

    GetStaffWith(id: string) {
        return this.http.get(`${this.url}getstaff/${id}`);
    }

    GetStaff() {
        return this.http.get(`${this.url}getstaff`);
    }

    SetStaff(value:any) {
        return this.http.post(`${this.url}setstaff`, value);
    }
}