import { ActiveUser } from './../models/ActiveUser';
import { Injectable,Inject, PLATFORM_ID } from '@angular/core';
import { AkibaType } from '../enum/akibaType.enum';
import { Akiba } from '../models/akiba';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class SystemDataService {

  
  
 
    constructor(){

    }

    public setCompany(id:any){
        this.set("company", id); 
    }

    public getCompany(){
       return this.get("company");
    }
    public getStaff() : string{
       
        return this.get("staff");
    }
    setStaff(arg0: any): any {
        this.set("staff", arg0);
      }
    public setTranscationType(value: AkibaType){
        this.set("transcationType", value);
    }
    public setToken(value:string){
        this.set("Token", value); 
    }
    public setTempeId(id:any){
        this.set("tempId", JSON.stringify(id)); 
    }
    public getTempeId<T>() {
        return JSON.parse(this.get("tempId")) as T; 
    }
    public getToken(){
        return this.get("Token"); 
    }
    public getTranscationType():AkibaType{
        return parseInt(this.get("transcationType")) as AkibaType; 
    }

    public setActiveUser(arg0: any): any {
        this.set("activeUser", arg0);
      }
    public getActiveUser(): ActiveUser{
        return this.get("activeUser") as ActiveUser; 
    }
    public setCustomer(value:string){
        this.set("customer", value); 
    }
    public getCustomer():string{
        return this.get("customer"); 
    }
   private set(key:string, value:any){
       
        localStorage.setItem(key, value); 
       
    }
   private get(key:string) :any{
        return  localStorage.getItem(key) || '';
    }
}

