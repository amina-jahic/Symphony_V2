import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../models/question-answer.model';
import { Question } from '../models/question.model';
import { Questionnaire } from '../models/questionnaire.model';


@Injectable()
export class QuestionnaireService {
    private API_BASE_URL = 'https://localhost:44381/api';

    constructor(private httpClient: HttpClient) { }

  GetQuestions(): Observable<Question[]> {
    return this.httpClient.get<Question[]>(`${this.API_BASE_URL}/Questionnaire`);
  }

  VerifyUser(questionnaire: Questionnaire): Observable<any> {
    return this.httpClient.post<Question[]>(`${this.API_BASE_URL}/Questionnaire/VerifyUser`, questionnaire);
  }

  PostQuestions(questionAnswers: QuestionAnswer[]): Observable<any> {
    return this.httpClient.post<QuestionAnswer[]>(`${this.API_BASE_URL}/Questionnaire/PostQuestions`, questionAnswers);
  }

  CheckQuestionner(questionnerId: number): Observable<boolean>{
    return this.httpClient.get<boolean>(`${this.API_BASE_URL}/Questionnaire/${questionnerId}`)
  }

}