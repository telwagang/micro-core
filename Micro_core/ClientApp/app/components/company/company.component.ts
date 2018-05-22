import { Component, OnInit } from '@angular/core';
import { CompanyService } from "./company.service";
import { FormBase } from '../form/formmodel/FormBase';
import { SystemDataService } from "../../services/systemData.service";
import { Company } from '../../models/company';


@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
  providers: [CompanyService, SystemDataService]
})
export class CompanyComponent implements OnInit {
  error: boolean;
  questions: any;

  constructor(private cs: CompanyService,
    private sysdata: SystemDataService) {
    this.cs.getQuestions()
      .subscribe(result => {
      this.questions = result as FormBase<any>;
        console.log(this.questions);
        this.error = false;
      });

  }

  ngOnInit() {
  }

  save(value: any) {
    this.cs.setCompany(JSON.parse(value))
      .subscribe(response => {
        this.error = false
        var company = response as Company;

        this.sysdata.setCompany(company.companyId);
      },
        erro =>{ this.error = true; console.log(erro); },
        () => console.log('done'));
  }
}
