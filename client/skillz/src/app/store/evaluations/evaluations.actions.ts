import { createAction, props } from '@ngrx/store';
import { EvaluationQuestion } from 'src/app/models/evaluations/evaluationQuestion';

export const set_questions = createAction(
  '[Questions] set_questions',
  props<{ questions: EvaluationQuestion[] }>()
);

export const set_question = createAction(
  '[Questions] set_question',
  props<{ question: EvaluationQuestion }>()
);
