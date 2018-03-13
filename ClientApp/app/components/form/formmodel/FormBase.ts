import { QuestionBase } from "./QuestionBase";

export class FormBase<T>{
    Id:any;
    Name:string;
    key:string;
    Questions: QuestionBase<T>[];

    constructor(options: {
        Id?:any,
        Name?:string,
        key?:string,
        Questions?:QuestionBase<T>[]
    } = {}){
        this.Id = options.Id || 0;
        this.Name = options.Name || '';
        this.key = options.key || '';
        this.Questions = options.Questions || []; 

    }
}