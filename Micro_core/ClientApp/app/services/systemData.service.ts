import { Injectable,Inject } from '@angular/core';
import { AkibaType } from '../enum/akibaType.enum';
import { Akiba } from '../models/akiba';

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
        this.set("staff", 1);
        return this.get("staff");
    }
    public setTranscationType(value: AkibaType){
        this.set("transcationType", value);
    }
    public setToken(value:string){
        this.set("Token", value); 
    }
    public getToken(){
        return this.get("Token"); 
    }
    public getTranscationType():AkibaType{
        return parseInt(this.get("transcationType")) as AkibaType; 
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
   private get(key:string) :string{
        return localStorage.getItem(key) || '';
    }
}
