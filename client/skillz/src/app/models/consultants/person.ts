import { BaseAuditableEntity } from '../base/baseAuditableEntity';

export class Person extends BaseAuditableEntity {
  firstName: string;
  lastName: string;
  constructor(firstName, lastName) {
    super();
    this.firstName = firstName;
    this.lastName = lastName;
  }
}
