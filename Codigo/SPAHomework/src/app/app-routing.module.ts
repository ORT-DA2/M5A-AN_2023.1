import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeworkDetailGuard } from './guards/homework-detail.guard';
import { HomeworkCreateComponent } from './homework-create/homework-create.component';
import { HomeworkDetailComponent } from './homework-detail/homework-detail.component';
import { HomeworksListComponent } from './homeworks-list/homeworks-list.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  { path: 'homeworks', component: HomeworksListComponent },
  { path: 'homeworks/new', component: HomeworkCreateComponent },
  { path: 'homeworks/:id', 
    component: HomeworkDetailComponent,
    canActivate: [HomeworkDetailGuard]
  },
  { path: 'welcome', component:  WelcomeComponent }, 
  { path: '', redirectTo: 'welcome', pathMatch: 'full' },
  { path: '**', redirectTo: 'welcome', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
