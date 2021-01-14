import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Consultant } from 'src/app/models/consultants/consultant';
import { ConsultantsService } from 'src/app/services/consultants/consultants.service';
import { add_consultant, set_consultants } from 'src/app/store/consultants/consultants.actions';

@Component({
  selector: 'app-consultants',
  templateUrl: './consultants.component.html',
  styleUrls: ['./consultants.component.sass'],
})
export class ConsultantsComponent implements OnInit {
  consultants$: Observable<Consultant[]>;

  isActive: boolean = false;
  consultant = {
    firstname: '',
    lastname: '',
    email: '',
    phone: '',
    mobile: '',
    companyId: '7c299ba6-b937-429a-7f90-08d8b865aa1b' // temporarily hardcoded ID
  };

  constructor(private router: Router, private store: Store<{ consultants }>, private consultantsService: ConsultantsService) {
    this.consultantsService.getConsultants().subscribe(consultants => this.store.dispatch(set_consultants({ consultants })));
  }

  ngOnInit(): void {
    this.consultants$ = this.store.select(
      (state) => state.consultants.consultants
    );
  }

  showAddConsultantModal() {
    this.isActive = true;
  }

  closeAddConsultantModal() {
    this.isActive = false;
  }

  closeAndCancelAddConsultantModal() {
    this.closeAddConsultantModal();
  }

  closeAndClearAddConsultantModal() {
    this.closeAddConsultantModal();
  }

  saveConsultant() {
    this.consultantsService.postConsultant(this.consultant).subscribe(consultant => this.store.dispatch(add_consultant({ consultant })))
    //    this.$store.dispatch('Consultants/post_consultant', {
    //           "firstname": this.firstname,
    //           "lastname": this.lastname,
    //           "companyId": "C0884A97-27BB-4DE7-96B2-C869ACFA8EA0",
    //           "email": this.email,
    //           "phone": this.workphone,
    //           "mobilePhone": this.personalphone
    //  });
    this.closeAndClearAddConsultantModal();
  }

  goToConsultantDetail(id) {
    this.router.navigate([`/skillz/consultants/${id}`]);
  }
}
