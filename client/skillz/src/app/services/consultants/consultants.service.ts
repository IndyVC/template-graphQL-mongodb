import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { API_URL } from '../../config/config';
import { Consultant } from 'src/app/models/consultant';

@Injectable({
  providedIn: 'root',
})
export class ConsultantsService {
  constructor(private httpClient: HttpClient) {}

  getConsultants(): Observable<Consultant[]> {
    return this.httpClient
      .get(`${API_URL}/Consultants`)
      .pipe(map((v) => v as Array<Consultant>));
  }
}
