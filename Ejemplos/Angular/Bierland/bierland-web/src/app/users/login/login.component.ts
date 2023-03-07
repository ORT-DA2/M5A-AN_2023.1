import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Login } from '../../../models/Login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  nickname: string;
  password: string;
  constructor(private usersService: UsersService,  private router: Router) { }

  login(): void {
    const login = new Login(this.nickname, this.password);
    this.usersService.login(login).subscribe(
      (res: string) => {
        localStorage.setItem('token', res);
        this.router.navigate(['/pubs']);
      },
      err => {
        alert(err.error);
        console.log(err);
      }
    );
  }
}
