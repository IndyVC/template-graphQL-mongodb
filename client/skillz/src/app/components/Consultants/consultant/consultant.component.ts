import { Component, OnInit } from '@angular/core';
import { ConsultantsService } from 'src/app/services/consultants.service';

@Component({
  selector: 'app-consultant',
  templateUrl: './consultant.component.html',
  styleUrls: ['./consultant.component.sass']
})
export class ConsultantComponent implements OnInit {

  constructor(private consultantsService: ConsultantsService) { }

  ngOnInit(): void {
    this.consultantsService.test()
  }

}
