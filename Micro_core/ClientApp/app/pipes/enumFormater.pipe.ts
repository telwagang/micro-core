import { Pipe, PipeTransform } from '@angular/core';
import { MicroDataType } from '../enum/fields.enum';

@Pipe({
  name: 'enumFormater'
})
export class enumFormater implements PipeTransform {

  transform(value: any, args?: any): any {
     
    return MicroDataType[value];
  }

}