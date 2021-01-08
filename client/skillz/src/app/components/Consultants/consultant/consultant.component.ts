import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, pipe } from 'rxjs';
import { ConsultantsService } from 'src/app/services/consultants/consultants.service';
import { Store } from '@ngrx/store';
import { Consultant } from 'src/app/models/consultant';
import {
  set_consultants,
  set_consultant,
} from '../../../store/consultants/consultants.actions';

@Component({
  selector: 'app-consultant',
  templateUrl: './consultant.component.html',
  styleUrls: ['./consultant.component.sass'],
})
export class ConsultantComponent implements OnInit {
  consultants$: Observable<Consultant[]>;
  consultant$: Observable<Consultant>;

  panelActive: string = 'contracts';
  addSkillIsActive: boolean = false;
  contractsVisible: boolean = true;

  constructor(
    private consultantsService: ConsultantsService,
    private store: Store<{ consultants }>
  ) {
    this.consultantsService.getConsultants().subscribe((consultants) => {
      this.store.dispatch(set_consultants({ consultants: consultants }));
      this.store.dispatch(set_consultant({ consultant: consultants[0] }));
    });
  }

  ngOnInit(): void {
    this.consultants$ = this.store.select(
      (state) => state.consultants.consultants
    );
    this.consultant$ = this.store.select(
      (state) => state.consultants.consultant
    );
    this.consultant$.subscribe((e) => console.log(e));
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
