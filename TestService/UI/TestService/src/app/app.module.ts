import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from 'src/Components/login/login.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { TestListComponent } from 'src/Components/test-list/test-list.component';
import {MatListModule} from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { QuestionsComponent } from 'src/Components/questions/questions.component';
import { HeaderComponent } from 'src/Components/header/header.component';
import { ResultScreenComponent } from 'src/Components/result-screen/result-screen.component';
import { QuestionsModule } from 'src/Components/questions/questions/questions.module';
import { QuestionsRoutingModule } from 'src/Components/questions/questions/questions-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TestListComponent,
    HeaderComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    HttpClientModule,
    MatListModule,
    FormsModule,
    ReactiveFormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
