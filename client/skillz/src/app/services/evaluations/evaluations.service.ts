import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EvaluationQuestion } from 'src/app/models/evaluations/evaluationQuestion';
import { map } from 'rxjs/operators';
import { API_URL } from '../../config/config';

@Injectable({
  providedIn: 'root',
})
export class EvaluationsService {
  constructor(private httpClient: HttpClient) {}

  getQuestions(): Observable<EvaluationQuestion[]> {
    return this.httpClient
      .get(`${API_URL}/Questions`)
      .pipe(map((v) => v as Array<EvaluationQuestion>));
  }
}
