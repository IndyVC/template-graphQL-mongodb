import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

//Components
import { MainSubNavigationComponent } from './components/Navigation/main-sub-navigation/main-sub-navigation.component';
import { ConsultantComponent } from './components/Consultants/consultant/consultant.component';
import { ConsultantsComponent } from './components/Consultants/consultants/consultants.component';
import { EmployeeComponent } from './components/Employees/employee/employee.component';
import { EmployeesComponent } from './components/Employees/employees/employees.component';
import { QuestionsComponent } from './components/Evaluations/questions/questions.component';
import { SkillsComponent } from './components/Skills/skills/skills.component';
import { WageCalculatorComponent } from './components/WageCalculator/wage-calculator/wage-calculator.component';
import { EvaluationsComponent } from './components/Evaluations/evaluations/evaluations.component';

//State (ngrx)
import { StoreModule } from '@ngrx/store';
import { consultantsReducer } from './store/consultants/consultants.reducer';
import { evaluationsReducer } from './store/evaluations/evaluations.reducer';

@NgModule({
  declarations: [
    AppComponent,
    MainSubNavigationComponent,
    ConsultantComponent,
    ConsultantsComponent,
    EmployeeComponent,
    EmployeesComponent,
    QuestionsComponent,
    SkillsComponent,
    WageCalculatorComponent,
    EvaluationsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    FormsModule,
    StoreModule.forRoot({
      consultants: consultantsReducer,
      evaluations: evaluationsReducer,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
