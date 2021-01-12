import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { EvaluationQuestion } from 'src/app/models/evaluations/evaluationQuestion';
import { EvaluationsService } from 'src/app/services/evaluations/evaluations.service';
import { set_questions } from 'src/app/store/evaluations/evaluations.actions';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.sass'],
})
export class QuestionsComponent implements OnInit {
  questions$: Observable<EvaluationQuestion[]>;

  isActive: boolean = false;
  hasError: boolean = false;
  question = {
    title: '',
    description: '',
    group: '',
    category: '',
  };

  constructor(
    private evaluationsService: EvaluationsService,
    private store: Store<{ evaluations }>
  ) {
    this.evaluationsService.getQuestions().subscribe((questions) => {
      this.store.dispatch(set_questions({ questions }));
    });
  }

  ngOnInit(): void {
    this.questions$ = this.store.select((state) => state.evaluations.questions);
  }

  showAddQuestionModal() {
    // if(this.$store.state.Evaluations.categories.all.length == 0){
    //   this.$store.dispatch('Evaluations/fetch_evaluationData');
    // }
    this.isActive = true;
  }

  closeAddQuestionModal() {
    this.isActive = false;
  }

  closeAndCancelAddQuestionModal() {
    this.closeAddQuestionModal();
  }

  closeAndClearAddQuestionModal() {
    this.closeAddQuestionModal();
    for (let prop in this.question) {
      this.question[prop] = '';
    }
  }

  saveQuestion() {
    //   this.$store.dispatch('Evaluations/post_question', {
    //           "title": this.title,
    //           "description": this.description,
    //           "companyId": "C0884A97-27BB-4DE7-96B2-C869ACFA8EA0",
    //           "evaluationQuestionTypeId": "C0211629-F17B-42BE-A274-F3DA775B5D2D",
    //           "evaluationQuestionCategoryId": this.category,
    //           "evaluationQuestionGroupId": this.group
    //  });
    this.closeAndClearAddQuestionModal();
  }
}
