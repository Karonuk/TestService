import { Component, Input, NgModule, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionViewModel } from 'src/models/QuestionViewModel';
import { ResultViewModel } from 'src/models/ResultViewModel';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})

export class QuestionsComponent implements OnInit {
  questions!:QuestionViewModel[];
  index!:number;
  maxCount!:number;
  anwswers!:number[];
  isAnswerChoosen=false;
  isFinished=false;
  Result!:ResultViewModel;
  //isChecked=true;

  constructor(private api:ApiService,private rout:ActivatedRoute,private router:Router) {
  }

  ngOnInit(): void {
    const id = Number(this.rout.snapshot.paramMap.get('id'));

    this.api.getQuestionsByTest(id).subscribe((questionsList:any)=>{
      this.questions=questionsList;
      this.maxCount=questionsList.length;
      this.questions.forEach((question)=>{
        question.answers.forEach((anwswer)=>{
          anwswer.isChecked=false;
        })
      })
    });

    this.index=0;
    this.anwswers=[];
  }
  clickNext(){
    if(this.index<this.maxCount){
      let answerId=0;
      this.questions[this.index].answers.forEach((elem)=>{
        if(elem.isChecked){
          answerId=elem.id;
        }
      });
      this.anwswers.push(answerId);
      this.index++;
      this.isAnswerChoosen=false;
    }
  }

  clickFinish(){
    let answerId=0;
    this.questions[this.index].answers.forEach((elem)=>{
      if(elem.isChecked){
        answerId=elem.id;
      }
    });
    this.anwswers.push(answerId);
    this.isAnswerChoosen=false;
    this.api.getResult(this.anwswers).subscribe((result:any)=>{
      this.Result=result;;
      this.isFinished=true;
    });
  }

  onChange(id:number){
    console.log(this.isAnswerChoosen);
    this.questions[this.index].answers.forEach((elem)=>{
      this.isAnswerChoosen=true;
      if(elem.id!=id){
        elem.isChecked=false;
      }
      else{
        elem.isChecked=true;
      }
    });

  }

}
