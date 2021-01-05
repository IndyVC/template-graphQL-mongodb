import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass'],
})
export class AppComponent {
  title = 'skillz';
  showSkillsNav = true;
  showCalcNav = false;

  showMenu(section: string) {
    switch (section) {
      case 'skills':
        this.showSkillsNav = true;
        this.showCalcNav = false;
        break;
      case 'calc':
        this.showSkillsNav = false;
        this.showCalcNav = true;
        break;
    }
  }
}
