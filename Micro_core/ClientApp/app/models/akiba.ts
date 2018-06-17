import { AkibaType } from "../enum/akibaType.enum";

export interface Akiba{
    Id:number,
    customerId:string,
    staffId:number,
    ctORdt:AkibaType,
    amount:number,
    createdDate:Date
}