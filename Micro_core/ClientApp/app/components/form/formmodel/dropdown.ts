import { QuestionBase } from './QuestionBase';

export class Dropdown extends QuestionBase<string> {
    controlType = 'dropdown';
    options: { key: string, value: string, seleted?:boolean }[] = [];
    mutlipleSelect:boolean = false; 
    
    constructor(options: {} = {}) {
        super(options);
        this.getType(options);
       
    }

    private getType(options:any){
        this.options = options['options'] || '';
        this.mutlipleSelect = options['mutlipleSelect'] || false;
    }
    
}
