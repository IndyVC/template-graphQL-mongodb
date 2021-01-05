import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from '../app/app.component';
import { SkillsComponent } from './components/Skills/skills/skills.component';
import { ConsultantsComponent } from './components/Consultants/consultants/consultants.component';
import { ConsultantComponent } from './components/Consultants/consultant/consultant.component';
import { EmployeesComponent } from './components/Employees/employees/employees.component';
import { EmployeeComponent } from './components/Employees/employee/employee.component';
import { QuestionsComponent } from './components/Evaluations/questions/questions.component';
import { WageCalculatorComponent } from './components/WageCalculator/wage-calculator/wage-calculator.component';
import { EvaluationsComponent } from './components/Evaluations/evaluations/evaluations.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'skillz/skills',
        component: SkillsComponent,
      },
      {
        path: 'skillz/consultants',
        component: ConsultantsComponent,
      },
      {
        path: 'skillz/consultants/:id',
        component: ConsultantComponent,
      },
      {
        path: 'skillz/employees',
        component: EmployeesComponent,
      },
      {
        path: 'skillz/employees/:id',
        component: EmployeeComponent,
      },
      {
        path: 'skillz/evaluations',
        component: EvaluationsComponent,
      },
      {
        path: 'skillz/questions',
        component: QuestionsComponent,
      },
    ],
  },
  {
    path: 'calc',
    component: WageCalculatorComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
