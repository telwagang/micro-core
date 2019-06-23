import { Router } from '@angular/router';
import { EntityType, EntityTypeFunc } from './../../../models/entityType';
import { FormBase } from './../../form/formmodel/FormBase';
import { BuilderService } from './../builder.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-entity',
  templateUrl: './entity.component.html',
  styleUrls: ['./entity.component.css'],
  providers: [BuilderService]
})
export class EntityComponent implements OnInit {

  entityQuestions: any; 
  entity:EntityType[] = []; 
  IsView:boolean = false; 

  constructor(private bs: BuilderService) { }

  ngOnInit() {
   this.buildEntityType(0); 
   this.LoadTable();
  }

  buildEntityType(id:number=0){
    this.bs.buildEntityType(id).
    subscribe(x=> {
      
      this.entityQuestions = x as FormBase<any>; 
      this.IsView = true;
    });
  }
LoadTable(){
  this.bs.getEntitTypes()
  .subscribe(x=> {
    console.log(x);
    this.entity = x.data; 
  })
}

  saveEntity(value:any){
  
   var entitytype = JSON.parse(value) as EntityType; 
  
   if(entitytype.name  == '') return; 
  
   entitytype.delete = false;
   entitytype.active = false;
   
   entitytype.id = entitytype.id ? entitytype.id : 0; 
   
   this.bs.setEntity(entitytype)
   .subscribe(v=> {
     console.log(v); 
     this.buildEntityType(0); 
     this.LoadTable();
   });
   
  }
}
