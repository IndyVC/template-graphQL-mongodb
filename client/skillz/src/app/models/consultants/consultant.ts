import { StringMap } from '@angular/compiler/src/compiler_facade_interface';
import { Person } from './person';

export class Consultant extends Person {
  email: string;
  phone: string;
  mobile: string;
  functionName: string;
  functionLevel: string;
  birthDate: Date;
  companyId:string;
  
}
