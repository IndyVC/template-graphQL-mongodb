import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, pipe, of } from 'rxjs';
import { ConsultantsService } from 'src/app/services/consultants/consultants.service';
import { Store } from '@ngrx/store';
import { Consultant } from 'src/app/models/consultants/consultant';
import {
  set_consultants,
  set_consultant,
} from '../../../store/consultants/consultants.actions';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-consultant',
  templateUrl: './consultant.component.html',
  styleUrls: ['./consultant.component.sass'],
})

export class ConsultantComponent implements OnInit {
  consultant$: Observable<Consultant>;

  panelActive: string = 'contracts';
  addSkillIsActive: boolean = false;
  contractsVisible: boolean = true;
  skills: any = {
    rating: 0,
    category: 1,
    skill: '',
  };

  constructor(
    private consultantsService: ConsultantsService,
    private store: Store<{ consultants }>,
    private router: ActivatedRoute
  ) {
    this.consultantsService.getConsultants().subscribe((consultants) => {
      this.store.dispatch(set_consultants({ consultants: consultants }));
    });
    const consultantId = this.router.snapshot.paramMap.get('id');
    this.consultantsService
      .getConsultantById(consultantId)
      .subscribe((consultant) => {
        this.store.dispatch(set_consultant({ consultant: consultant }));
      });
  }

  ngOnInit(): void {
    this.consultant$ = this.store.select(
      (state) => state.consultants.consultant
    );
  }

  show(_, menuItem): any {
    this.panelActive = menuItem;
  }
  closeAndCancelAddSkillModal(): any {
    this.addSkillIsActive = false;
  }

  showAddSkillModal(id): any {
    // this.skills.category = id;
    this.addSkillIsActive = true;
  }

  saveSkill(): any {
    console.log(this.skills);
  }

  log(e): void {
    console.log(e);
  }
}
