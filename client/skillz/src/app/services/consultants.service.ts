import { Injectable } from '@angular/core';
import axios from 'axios';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultantsService {

  p

  constructor() {
    console.log("created")
  }

  test() {
    axios.get("https://jsonplaceholder.typicode.com/posts");
  }
}
