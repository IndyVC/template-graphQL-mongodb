import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, pipe } from 'rxjs';
import { ConsultantsService } from 'src/app/services/consultants.service';
import { map, tap } from 'rxjs/operators';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { getAll } from '../../../store/consultants/consultants.actions';
@Component({
  selector: 'app-consultant',
  templateUrl: './consultant.component.html',
  styleUrls: ['./consultant.component.sass'],
})
export class ConsultantComponent implements OnInit {
  panelActive: string = 'contracts';
  addSkillIsActive: boolean = false;
  // skills = new FormGroup({
  //   rating: new FormControl(""),
  //   category: new FormControl(""),
  //   lastName = new FormControl('')
  // })

  contractsVisible: boolean = true;
  posts$: Observable<any>;
  consultants$: Observable<any>;

  constructor(
    private consultantsService: ConsultantsService,
    private store: Store<{ consultants }>
  ) {
    store
      .select((state) => state.consultants.consultants)
      .subscribe((val) => console.log(val));
    this.consultants$ = store.select((state) => state.consultants.consultants);
  }

  ngOnInit(): void {
    this.posts$ = this.consultantsService.getPosts();
    this.store.dispatch(getAll());
  }

  show(evt, menuItem): any {
    this.panelActive = menuItem;
  }
  closeAndCancelAddSkillModal(): any {
    this.addSkillIsActive = false;
  }
  showAddSkillModal(id): any {
    // this.skills.category = id;
    this.addSkillIsActive = true;
  }
  saveSkill(): any {}
}
