import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { MovieItemComponent } from './components/movie-item/movie-item.component';
import { MoviesFilterPipe } from './components/movie-list/pipes/movies-filter.pipe';
import { MoviesService } from './services/movies.service';
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { BackButtonComponent } from './components/back-button/back-button.component';
import { MenuComponent } from './components/menu/menu.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { ResponseInterceptor } from './interceptors/response.interceptor';
import { LoadingService } from './services/loading.service';
import { LoaderComponent } from './components/loader/loader.component';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';
import { AdminComponent } from './components/admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    MovieListComponent,
    MovieItemComponent,
    MoviesFilterPipe,
    MovieFormComponent,
    BackButtonComponent,
    MenuComponent,
    LoaderComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    MoviesService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ResponseInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
    LoadingService,
    AuthService,
    AuthGuard,
    RoleGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
