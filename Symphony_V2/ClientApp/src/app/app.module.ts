import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing.module';
import { CandidateManagementComponent } from './candidate-management/candidate-management.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { QuestionnaireComponent } from './questionnaire/questionnaire.component';
import { QuestionnaireService } from './services/questionnaire.service';
import { UserService } from './services/user.service';
import { VerifyQuestionnnaireComponent } from './verify-questionnnaire/verify-questionnnaire.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CandidateManagementComponent,
    QuestionnaireComponent,
    AddCandidateComponent,
    VerifyQuestionnnaireComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [UserService, QuestionnaireService],
  bootstrap: [AppComponent]
})
export class AppModule { }
