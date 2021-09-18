import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Questionnaire } from '../models/questionnaire.model';
import { QuestionnaireService } from '../services/questionnaire.service';

@Component({
  selector: 'app-verify-questionnnaire',
  templateUrl: './verify-questionnnaire.component.html',
  styleUrls: ['./verify-questionnnaire.component.css']
})
export class VerifyQuestionnnaireComponent implements OnInit {

  routerSunscription: Subscription;
  questionnaireId: string;
  pin: string;
  valid = true;

  constructor(private route: ActivatedRoute, private questionnaireService: QuestionnaireService, private router: Router) { }

  ngOnInit(): void {
    this.routerSunscription = this.route.params.subscribe((params) => {
      this.questionnaireId = params['id'];
    });
  }

  verifyPin() {
    const questionnaire: Questionnaire = {
      id: parseInt(this.questionnaireId, 10),
      pin: this.pin,
      questionAnswers: []
    }
    this.questionnaireService.VerifyUser(questionnaire).subscribe(data => {
      if(data)
      {
        this.router.navigate([`questionnaire/${this.questionnaireId}`]);
        this.valid = true;
      }
      this.valid = false;

    })
  }

}
