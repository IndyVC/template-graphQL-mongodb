import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, pipe } from 'rxjs';
import { ConsultantsService } from 'src/app/services/consultants.service';
import { map, tap } from 'rxjs/operators';
@Component({
  selector: 'app-consultant',
  templateUrl: './consultant.component.html',
  styleUrls: ['./consultant.component.sass']
})
export class ConsultantComponent implements OnInit {

  posts$: Observable<any>;

  constructor(private consultantsService: ConsultantsService) { }

  ngOnInit(): void {
    this.posts$ = this.consultantsService.getPosts();
  }

}
