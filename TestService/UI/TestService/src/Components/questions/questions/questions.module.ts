import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionsComponent } from '../questions.component';
import { QuestionsRoutingModule } from './questions-routing.module';
import { ResultScreenComponent } from 'src/Components/result-screen/result-screen.component';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [QuestionsComponent,ResultScreenComponent],
  imports: [
    CommonModule,
    QuestionsRoutingModule,
    MatButtonModule
  ]
})
export class QuestionsModule { }
