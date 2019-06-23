import { QuestionBase } from './QuestionBase';

export class DropdownMultiple extends QuestionBase<string> {
    controlType = 'mutlipleSelect';
    options: { key: string, value: string, selected?:boolean }[] = [];
    
    constructor(options: {} = {}) {
        super(options);
        this.getType(options);
       
    }

    private getType(options:any){
        this.options = options['options'] || '';
    }
    
}