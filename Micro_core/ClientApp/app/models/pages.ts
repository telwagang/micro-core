import { EntityType } from './entityType';
import { MicroArithmetic, MicroPageType } from './../enum/fields.enum';


export interface Pages {
    id: number;
    name: string;
    arithmeticType: MicroArithmetic;
    type: MicroPageType;
    active: boolean;
    delete: boolean;
    entityTypes: EntityType[];
}
export interface PagesFunc extends Function {
    prototype: Pages;
    new (): Pages;
}
var Pages: PagesFunc;

