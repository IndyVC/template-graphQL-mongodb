import { createAction, props } from '@ngrx/store';
import { Consultant } from 'src/app/models/consultants/consultant';

export const set_consultants = createAction(
  '[Consultant] set_consultants',
  props<{ consultants: Consultant[] }>()
);
export const set_consultant = createAction(
  '[Consultant] set_consultant',
  props<{ consultant: Consultant }>()
);
