import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from 'src/Components/login/login.component';
import { QuestionsComponent } from 'src/Components/questions/questions.component';
import { ResultScreenComponent } from 'src/Components/result-screen/result-screen.component';
import { TestListComponent } from 'src/Components/test-list/test-list.component';
import { AuthGuard } from 'src/guard/auth.guard';

const routes: Routes = [{
  path: '',
  pathMatch:'full',
  component:LoginComponent
},
{
  path:'test-list',
  component:TestListComponent,
  canActivate:[AuthGuard],
},
{
  path:'questions',
  loadChildren: () =>
      import('src/Components/questions/questions/questions.module').then(
        (m) => m.QuestionsModule
      ),
  canActivate:[AuthGuard],
},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {  }
