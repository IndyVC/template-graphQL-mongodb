import { Base } from './base';

export class BaseAuditableEntity extends Base {
  created: Date;
  modified: Date;
}
