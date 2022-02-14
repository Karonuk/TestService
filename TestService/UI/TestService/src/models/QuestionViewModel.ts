import { AnswerViewModel } from "./AnswerViewModel";

export interface QuestionViewModel{
id:number;
questionText:string;
answers:AnswerViewModel[]
}
