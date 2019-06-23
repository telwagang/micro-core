import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { QuestionBase } from '../formmodel/QuestionBase';
import { DropdownMultiple } from '../formmodel/dropdownMultiple';
@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent implements OnInit {

  @Input() question: QuestionBase<any>;
  @Input() form: FormGroup;

    constructor() {
        this.patchDropdown();
    }

  ngOnInit() {
  }

    patchDropdown() {

                // let input = this.question as DropdownMultiple; 
                // if (input != null) {
                //     this.form.controls[input.key]
                //         .patchValue(input.value); 
                // }
          
    }
  get isValid() { return this.form.controls[this.question.key].valid; }
}
