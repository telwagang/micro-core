import { QuestionBase } from './QuestionBase';

export class Dropdown extends QuestionBase<string> {
    controlType = 'dropdown';
    options: { key: string, value: string }[] = [];

    constructor(options: {} = {}) {
        super(options);
        this.getType(options);
    }

    private getType(options:any){
        this.options = options['options'] || '';
    }
}
