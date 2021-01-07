import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-sub-navigation',
  templateUrl: './main-sub-navigation.component.html',
  styleUrls: ['./main-sub-navigation.component.sass'],
})
export class MainSubNavigationComponent implements OnInit {
  @Input() showSkillsNav: Boolean;
  @Input() showCalcNav: Boolean;
  constructor() {
    console.log(window.location);
  }

  ngOnInit(): void {}

  isActive():string {
    if(window.location.pathname)
  }
}
