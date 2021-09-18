import { QuestionAnswer } from "./question-answer.model";

export interface Questionnaire {
    id:number;
    pin: string;
    questionAnswers: QuestionAnswer[];
}