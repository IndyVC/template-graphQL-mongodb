import { createReducer, on } from '@ngrx/store';
import { set_question, set_questions } from './evaluations.actions';

export const initialState = {
  questions: [],
  question: null,
};

const _evaluationsReducer = createReducer(
  initialState,
  on(set_questions, (state, { questions }) => ({
    ...state,
    questions: questions,
  })),
  on(set_question, (state, { question }) => ({ ...state, question: question }))
);

export function evaluationsReducer(state, action) {
  return _evaluationsReducer(state, action);
}
