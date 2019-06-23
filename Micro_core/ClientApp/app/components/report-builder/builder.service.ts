import { SystemDataService } from './../../services/systemData.service';
import { Pages } from './../../models/pages';
import { Fields, FieldsFunc } from './../../models/fields';
import { MicroResponse } from './../../models/micro-response';
import { EntityType } from './../../models/entityType';
import { AppHttpService } from './../../services/apphttp.service';
import { Injectable } from '@angular/core';
import { QuestionBase } from '../form/formmodel/QuestionBase';
import { Textbox } from '../form/formmodel/textbox';
import { map, concat } from 'rxjs/Operators';
import { FormBase } from '../form/formmodel/FormBase';
import { Dropdown } from '../form/formmodel/dropdown';
import { DropdownMultiple } from '../form/formmodel/dropdownMultiple';

@Injectable()
export class BuilderService {

  private readonly EntityUrl = 'EntityType/'
  constructor(private http: AppHttpService,
           public sys: SystemDataService) { }


  buildEntityType(s: number){
  
    return this.getEntityType(s).pipe(map(result => {
      const v = result as MicroResponse;
      const value = v.data as EntityType; 
     console.log(v); 
      const isnot = value == null;
      console.log(isnot);
      let questions: QuestionBase<any>[] = [
          new Textbox({
              key: 'name',
              label: 'Entity Type',
              type: 'text',
              value: !isnot ? value.name : '',
              required: false,
              order: 1
          })
      ];

      return new FormBase<any>({
          Id: !isnot ? value.id : 0,
          Name: "Entity Type Details",
          key: 'id',
          Questions: questions
      })
  }))

  }


  setEntity(value:EntityType){
    return this.http.post(`${this.EntityUrl}SetEntity`, JSON.stringify(value)); 
  }
  getEntityType(id: number){
    return this.http.get(`${this.EntityUrl}GetEntity/${id}`); 
  }

  getEntitTypes(){
    return this.http.get(`${this.EntityUrl}GetEntities`); 
  }

  buildFields(s: number){
  
    return this.getField(s).pipe(map(result => {
      const v = result as MicroResponse;
      const value = v.data as Fields; 
     console.log(v); 
      const isnot = value == null;
      console.log(isnot);
      let questions: QuestionBase<any>[] = [
          new Textbox({
              key: 'displayName',
              label: 'Display Name',
              type: 'text',
              value: !isnot ? value.displayName : '',
              required: false,
              order: 1
          }),
          new Dropdown({
            key: 'dataType',
            label: 'Data Type',
            options: [{
              key:"0" , value:"Select one option"
            },{
              key: '1', value: "String"
            },{key: '2', value: "Dropdown"},
            {key: '3', value: "Int" },
            {key: '4', value: "Decimal"},
            {key: '5', value: "DateType"},
            {key: '6', value: "DeepType"}
          ],
            //value: !isnot ? value.dataType : '0',
            required: true,
            order: 2
        }),
        new Textbox({
          key: 'key',
          label: 'Key',
          type: 'text',
          value: !isnot ? value.key : '',
          required: true,
          order: 3
      }),
      new Textbox({
        key: 'order',
        label: 'order',
        type: 'number',
        value: !isnot ? value.order : '',
        required: false,
        order: 4
    })
    ,new Dropdown({
            key: 'custom',
            label: 'Required Types',
            options: [{
              key:"0" , value:"Select one option"
            },{
              key: '1', value: "Required"
            },{key: '2', value: "System"},
            {key: '3', value: "Required & System" }
          ],
            value: !isnot ? value.custom : '3',
            required: true,
            order: 5
        })
      ];
      questions = questions.sort((a, b) => b.order - a.order);

      return new FormBase<any>({
          Id: !isnot ? value.id : 0,
          Name: "Fields Details",
          key: 'id',
          Questions: questions
      })
  }))

  }

  getField(id:any){
    return this.http.get(`${this.EntityUrl}GetField/${id}`); 
  }

  getFields(id:any){
    return this.http.get(`${this.EntityUrl}GetFields/${id}`); 
  }

   buildPage(s:number){
    return this.getPage(s).
    pipe(
      map((x:MicroResponse)=>{
      
      const value = x.data as Pages; 
     console.log(x); 
      const isnot = value == null;
      console.log(isnot);

      let questions: QuestionBase<any>[] = [
          new Textbox({
              key: 'name',
              label: 'Page Name',
              type: 'text',
              value: !isnot ? value.name : '',
              required: true,
              order: 1
          }),
          new Dropdown({
            key: 'arithmeticType',
            label: 'Arithmetic Oparation',
            options: [{
              key:"0" , value:"Select one option"
            },{
              key: '1', value: "Add"
            },{key: '2', value: "Substract"},
            {key: '3', value: "Multiplication" },
            {key: '4', value: "Division"}
          ],
            //value: !isnot ? value.dataType : '0',
            required: true,
            order: 2
        }), new Dropdown({
            key: 'type',
            label: 'Page Type',
            options: [{
              key:"0" , value:"Select one option"
            },{
              key: '1', value: "Divider"
            },{key: '2', value: "Page"}
          ],
            //value: !isnot ? value.dataType : '0',
            required: true,
            order: 3
        })
      ];

      return new FormBase<any>({
          Id: !isnot ? value.id : 0,
          Name: "Page Details",
          key: 'id',
          Questions: questions
      })
    }));
  }

  getPage(id:any){
    return this.http.get(`${this.EntityUrl}GetPage/${id}`); 
  }
  getPages(){
    return this.http.get(`${this.EntityUrl}GetPages`);
  }
  
  setPage(page:Pages){
  return this.http.post(`${this.EntityUrl}SetPage`, JSON.stringify(page)); 
  }
  
  async buildEntityPage(id:any){
      var f = <MicroResponse> await this.getPage(id).toPromise();
     
      
         const value = f.data as Pages; 
         const isnot = value == null ;
      
         this.sys.setTempeId(value); 

      const entities =  await this.getEntitiesForDropdown();  
      console.log(entities);
         let questions: QuestionBase<any>[] = [
             new Textbox({
                 key: 'name',
              label: 'Page Name',
              type: 'text',
              value: value.name ,
              required: true,
              order: 1

              }),
             new DropdownMultiple({
                 key: 'entityType',
                 label: 'Entity Types',
                 options: entities
                 })
             ];


         return new FormBase<any>({
             Id: isnot ? 0 : value.id,
             Name: "Entity Page mapping Details",
             key:"id",
             Questions : questions
         });
       
  }

  async getEntitiesForDropdown(){
    var f = <MicroResponse> await this.getEntitTypes().toPromise(); 
    var d = []; 
    for (const it of f.data as EntityType[]) {
        d.push({key:it.id, value:it.name});
    }
    return d; 

  }
}
