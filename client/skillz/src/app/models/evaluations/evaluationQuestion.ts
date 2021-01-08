import { BaseAuditableEntity } from '../base/baseAuditableEntity';
import { EvaluationQuestionCategory } from './evaluationQuestionCategory';
import { EvaluationQuestionGroup } from './evaluationQuestionGroup';

export class EvaluationQuestion extends BaseAuditableEntity {
  title: string;
  description: string;
  company_id: string;
  evaluationquestiongroup_id: string;
  evaluationQuestionCategory: EvaluationQuestionCategory;
  evaluationquestionecategory_id: string;
  evaluationQuestionGroup: EvaluationQuestionGroup;
}
