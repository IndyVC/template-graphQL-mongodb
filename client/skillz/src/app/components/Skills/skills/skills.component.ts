import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.sass'],
})
export class SkillsComponent implements OnInit {
  isActive: boolean = false;
  title: string = '';
  skill: string;
  description: string = '';
  category: string = '';
  panelActive: string = 'dev';

  constructor(private router: Router) {}

  ngOnInit(): void {}

  showAddSkillModal(): void {
    this.isActive = true;
  }

  closeAddSkillModal(): void {
    this.isActive = false;
  }

  closeAndCancelAddSkillModal(): void {
    this.closeAddSkillModal();
  }

  closeAndClearAddSkillModal(): void {
    this.closeAddSkillModal();
  }

  saveSkill(): void {
    this.closeAndClearAddSkillModal();
  }

  goToConsultantDetail(id): void {
    this.router.navigate([`/skillz/consultants/${id}`]);
  }

  show(evt, menuItem): void {
    this.panelActive = menuItem;
  }
}
