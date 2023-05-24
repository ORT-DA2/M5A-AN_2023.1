import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { ADMIN_URL, MOVIE_FORM_URL, MOVIE_LIST_URL } from './utils/routes';
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { AdminComponent } from './components/admin/admin.component';
import { RoleGuard } from './guards/role.guard';
import { AuthGuard } from './guards/auth.guard';
import { ADMIN_ROLE } from './utils/auth.constants';

const routes: Routes = [
  { path: '', component: MovieListComponent },
  { path: MOVIE_LIST_URL, component: MovieListComponent },
  {
    path: MOVIE_FORM_URL,
    component: MovieFormComponent,
    canActivate: [AuthGuard],
  },
  {
    path: ADMIN_URL,
    component: AdminComponent,
    canActivate: [RoleGuard],
    data: {
      expectedRole: ADMIN_ROLE
    },
  },
  { path: '**', redirectTo: '' }, // this line goes at the end
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
