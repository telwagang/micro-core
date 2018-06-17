import { UserType } from "../enum/user-type.enum";

export interface ActiveUser {
    id:number,
    username:string,
    password:string, 
    apiKey:string,
    type:UserType,
    typeId:number,
    companyId:number
}