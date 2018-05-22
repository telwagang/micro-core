import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { QuestionBase } from '../formmodel/QuestionBase';
@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent implements OnInit {

  @Input() question: QuestionBase<any>;
  @Input() form: FormGroup;

  constructor() { }

  ngOnInit() {
  }

  get isValid() { return this.form.controls[this.question.key].valid; }
}
