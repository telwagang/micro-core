import { MicroDataType, MicroCustom } from './../enum/fields.enum';
export interface Fields {
    id: number;
    entityId: number;
    dataType: MicroDataType;
    displayName: string;
    type: string;
    key: string;
    required: boolean;
    system: boolean;
    order: number;
    deleted: boolean;
    custom:MicroCustom; 
}
export interface FieldsFunc extends Function {
    prototype: Fields;
    new (): Fields;
}
var Fields: FieldsFunc;
