import { createReducer, on } from '@ngrx/store';
import { getAll } from './consultants.actions';

export const initialState = {
  consultants: [],
};

const _consultantsReducer = createReducer(
  initialState,
  on(getAll, (state) => ({
    ...state,
    consultants: ['Indy', 'Sofie'],
  }))
);

export function consultantsReducer(state, action) {
  return _consultantsReducer(state, action);
}
