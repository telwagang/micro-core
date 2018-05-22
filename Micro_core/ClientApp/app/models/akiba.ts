import { AkibaType } from "../enum/akibaType.enum";

export interface Akiba{
    Id:number,
    customerId:string,
    staffId:number,
    transcationType:AkibaType,
    transcationAmount:number,
    date:Date
}