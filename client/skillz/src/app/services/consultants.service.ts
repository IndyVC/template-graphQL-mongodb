import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultantsService {


  constructor(private httpClient: HttpClient) {
  }

  getPosts(): Observable<any> {
    return this.httpClient.get("https://jsonplaceholder.typicode.com/todos");
  }
}
