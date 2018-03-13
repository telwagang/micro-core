import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { QuestionBase } from './questionbase';
import { FormBase } from './FormBase';

@Injectable()
export class FormService {
  constructor() { }

  toFormGroup(questions: FormBase<any>) {
    const group: any = {};

    group[questions.key] = new FormControl(questions.Id || '');

    questions.Questions.forEach(question => {
      group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
        : new FormControl(question.value || '');
    });
    return new FormGroup(group);
  }
  
}
