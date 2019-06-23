import { ActivatedRoute } from '@angular/router';
import { EntityType } from './../../../models/entityType';
import { MicroResponse } from './../../../models/micro-response';
import { FormBase } from './../../form/formmodel/FormBase';
import { BuilderService } from './../builder.service';
import { Component, OnInit } from '@angular/core';
import { Fields } from '../../../models/fields';
import { MicroCustom, MicroDataType } from '../../../enum/fields.enum';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.css'],
  providers: [BuilderService]
})
export class FieldsComponent implements OnInit {


  fieldQuestions: any; 
  fields:Fields[] = []; 
  IsView:boolean = false; 
  entityId:any; 
  entitytype:EntityType; 
  constructor(private Bs: BuilderService,
    private router : ActivatedRoute) {
      this.entityId = this.router.snapshot.paramMap.get('id');
     }

  ngOnInit() {
    this.buildFields(0);
    this.LoadTable();
  }

  buildFields(id:number){
    this.Bs.buildFields(id).
    subscribe(x=> {
      
      this.fieldQuestions = x as FormBase<any>; 
      this.IsView = true;
    });
  }

  LoadTable(){
    this.Bs.getFields(this.entityId)
    .subscribe((x:MicroResponse)=> {
      console.log(x);
      var entity = x.data as EntityType;
      this.fields = entity.fields;
      this.entitytype = entity;   
    })
  }

  saveFields(values:any){
    
    console.log(values); 
    
    var field = JSON.parse(values) as Fields; 
    
    field.required = field.custom == MicroCustom.Required || field.custom == MicroCustom.RequiredAndSystem; 
    field.system = field.custom == MicroCustom.System || field.custom == MicroCustom.RequiredAndSystem; 

    field.id = field.id ? field.id : 0 ; 
    field.entityId = parseInt(this.entityId); 
    
    field.type = field.dataType == MicroDataType.DropdownType ? "dropdown" : "text"; 

    field.dataType = field.dataType 
    console.log(field); 
    
    this.entitytype.fields = [field]; 

    console.log(this.entitytype); 

    this.Bs.setEntity(this.entitytype)
    .subscribe(x=> {
      console.log(x);
      this.LoadTable();
    }); 
    


  }

}
