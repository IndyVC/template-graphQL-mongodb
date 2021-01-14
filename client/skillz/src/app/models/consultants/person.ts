import { BaseAuditableEntity } from '../base/baseAuditableEntity';

export class Person extends BaseAuditableEntity {
  firstname: string;
  lastname: string;
  constructor(firstName, lastName) {
    super();
    this.firstname = firstName;
    this.lastname = lastName;
  }
}
