import { Component,EventEmitter, Input,Output, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { FormService } from '../formmodel/form.service';
import { QuestionBase } from '../formmodel/QuestionBase';
import { FormBase } from "../formmodel/FormBase";
import { DropdownMultiple } from '../formmodel/dropdownMultiple';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
  providers: [FormService]
})
export class FormComponent implements OnInit {

  @Input() questions: FormBase<any>;
  form: FormGroup;
  @Output() payLoad = new EventEmitter<{}>();

  constructor(private fs: FormService) { }

  ngOnInit() {
      this.form = this.fs.toFormGroup(this.questions);
  }

  onSubmit() {
    console.log(this.form.value);
    this.payLoad.emit(JSON.stringify(this.form.value));
    
  }
}
