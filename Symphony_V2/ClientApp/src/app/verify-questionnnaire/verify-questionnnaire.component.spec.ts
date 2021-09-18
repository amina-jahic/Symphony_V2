import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyQuestionnnaireComponent } from './verify-questionnnaire.component';

describe('VerifyQuestionnnaireComponent', () => {
  let component: VerifyQuestionnnaireComponent;
  let fixture: ComponentFixture<VerifyQuestionnnaireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerifyQuestionnnaireComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerifyQuestionnnaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
