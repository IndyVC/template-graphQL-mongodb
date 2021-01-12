import { createReducer, on } from '@ngrx/store';
import { set_consultant, set_consultants } from './consultants.actions';

export const initialState = {
  consultants: [],
  consultant: null,
};

const _consultantsReducer = createReducer(
  initialState,
  on(set_consultant, (state, { consultant }) => ({
    ...state,
    consultant: consultant,
  })),
  on(set_consultants, (state, { consultants }) => ({
    ...state,
    consultants: consultants,
  }))
);

export function consultantsReducer(state, action) {
  return _consultantsReducer(state, action);
}
