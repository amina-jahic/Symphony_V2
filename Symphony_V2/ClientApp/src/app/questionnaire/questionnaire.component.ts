import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { isJSDocThisTag } from 'typescript';
import { QuestionAnswer } from '../models/question-answer.model';
import { Question } from '../models/question.model';
import { QuestionnaireService } from '../services/questionnaire.service';
// import { QuestionnaireService } from '../services/questionnaire.service';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.css']
})
export class QuestionnaireComponent implements OnInit {

  questions: Question[];
  answerForm: FormGroup;
  routerSunscription: Subscription;
  questionnaireId: string;
  isQuestionnareAnswered = false;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private questionnaireService: QuestionnaireService) { 
    this.answerForm = this.createAnswerForm();
  }

  ngOnInit(): void {
    this.questionnaireService.GetQuestions().subscribe(data => {
      this.questions = data;
    });
    this.routerSunscription = this.route.params.subscribe((params) => {
      this.questionnaireId = params['id'];
    });
    
    if(this.questionnaireId.length > 0){
    this.questionnaireService.CheckQuestionner(parseInt(this.questionnaireId, 10)).subscribe(data =>{
      if(data){
        this.isQuestionnareAnswered = true;
      }
      this.isQuestionnareAnswered = false;
    })}
  }

  createAnswerForm() {
    return this.formBuilder.group({
      question1: [null],
      question2: [null],
      question3: [null],
      question4: [null],
      question5: [null],
      question6: [null],
      question7: [null],
      question8: [null],
      question9: [null],
      question10: [null]
    });
  }

  questionFormControlName(questionId: number) {
    return `question${questionId}`;
  }

  submitQuestionnaire() {
    const form = this.answerForm.getRawValue();

    let questionAnswers: QuestionAnswer[] = [];
    
    let answer1: QuestionAnswer = {
      questionId: 1,
      answerValue: +form.question1,
      questionnaireId: +this.questionnaireId
    }

    questionAnswers.push(answer1);

    let answer2: QuestionAnswer = {
      questionId: 2,
      answerValue: +form.question2,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer2);

    let answer3: QuestionAnswer = {
      questionId: 3,
      answerValue: +form.question3,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer3);

    let answer4: QuestionAnswer = {
      questionId: 4,
      answerValue: +form.question4,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer4);

    let answer5: QuestionAnswer = {
      questionId: 5,
      answerValue: +form.question5,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer5);

    let answer6: QuestionAnswer = {
      questionId: 6,
      answerValue: +form.question6,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer6);

    let answer7: QuestionAnswer = {
      questionId: 7,
      answerValue: +form.question7,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer7);

    let answer8: QuestionAnswer = {
      questionId: 8,
      answerValue: +form.question8,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer8);

    let answer9: QuestionAnswer = {
      questionId: 9,
      answerValue: +form.question9,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer9);

    let answer10: QuestionAnswer = {
      questionId: 10,
      answerValue: +form.question10,
      questionnaireId: +this.questionnaireId
    }
    questionAnswers.push(answer10);

    this.questionnaireService.PostQuestions(questionAnswers).subscribe(data =>{
      if(data)
      {
        this.isQuestionnareAnswered = true;
      }
    });
  }

}
