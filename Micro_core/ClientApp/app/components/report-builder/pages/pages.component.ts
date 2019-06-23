import { SystemDataService } from './../../../services/systemData.service';
import { EntityType } from './../../../models/entityType';
import { FormBase } from './../../form/formmodel/FormBase';
import { Pages } from './../../../models/pages';
import { Component, OnInit } from '@angular/core';
import { BuilderService } from '../builder.service';
import { FormBuilder } from '../../../../../node_modules/@angular/forms';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css'],
  providers: [BuilderService]
})
export class PagesComponent implements OnInit {

  pagesQuestions: any;
  pagesModelQuestions:any; 
  pages:Pages[] = []; 
  IsView:boolean = false; 
  IsModel:boolean = false; 
  constructor(private ds:BuilderService) { }

  ngOnInit() {
    this.buildEntityType();
    //this.LoadTable();
  }

  buildEntityType(id:number=0){
    this.ds.buildPage(id).
    subscribe(x=> {
      
      this.pagesQuestions = x as FormBase<any>; 
      this.IsView = true;
      this.LoadTable();
    });
  }
  buildModel(id:number = 0){
      this.ds.buildEntityPage(id).then
          (x => {
             this.IsView = false;
              this.pagesModelQuestions = x as FormBase<any>;
              this.IsModel = false; 
              this.IsView = true;
          });
  }
  
LoadTable(){
  this.ds.getPages()
  .subscribe(x=> {
    console.log(x);
    this.pages = x.data; 
  })
}
savePage(value:string){
  console.log(value); 
  
  var page = JSON.parse(value) as Pages; 
  
  page.id = page.id ? page.id : 0; 
  
  this.ds.setPage(page)
  .subscribe(x => {
  console.log(x); 
  this.LoadTable(); 
  this.buildEntityType(0);
  })
  
}
savePageEntity(value:any){
  console.log(value);
  var page = JSON.parse(value);

  var p = this.ds.sys.getTempeId<Pages>(); 
 console.log(p);
   p.entityTypes = [];
  for (let index = 0; index < page.entityType.length; index++) {
    const it = page.entityType[index];
    
    const f:EntityType ={id: parseInt(it),name:'', active:true,delete:false, pages:[], fields:[]}; 

    p.entityTypes.push(f); 
  }
   
  console.log(p);

  this.ds.setPage(p)
  .subscribe(x=>{
    this.LoadTable(); 
  });
}

}
