import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { CandidateManagementComponent } from './candidate-management/candidate-management.component';
import { QuestionnaireComponent } from './questionnaire/questionnaire.component';
import { VerifyQuestionnnaireComponent } from './verify-questionnnaire/verify-questionnnaire.component';

const routes: Routes = [
  { path: '', redirectTo: 'candidate-management', pathMatch: 'full' },
  { path: 'candidate-management', component: CandidateManagementComponent },
  { path: 'add-candidate', component: AddCandidateComponent },
  { path: 'questionnaire/:id', component: QuestionnaireComponent},
  { path: 'questionnaire-verify/:id', component: VerifyQuestionnnaireComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }