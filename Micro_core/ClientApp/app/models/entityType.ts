import { Pages } from './pages';
import { Fields } from './fields';
export interface EntityType {
    id: number;
    name: string;
    active: boolean;
    delete: boolean;
    pages: Pages[];
    fields: Fields[];
}
export interface EntityTypeFunc extends Function {
    prototype: EntityType;
    new (): EntityType;
}
var EntityType: EntityTypeFunc;