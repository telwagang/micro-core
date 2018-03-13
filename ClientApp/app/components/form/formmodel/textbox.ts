import { QuestionBase } from './QuestionBase';

export class Textbox extends QuestionBase<string> {
    controlType = 'textbox';
    type: string;

    constructor(options: {} = {}) {
        super(options);
        this.getType(options);
    }

    private getType(options:any){
        this.type = options['type'] || '';
    }
}
