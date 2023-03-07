import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-back-button',
  templateUrl: './back-button.component.html',
  styleUrls: ['./back-button.component.css']
})
export class BackButtonComponent implements OnInit {

  @Input() public url?: string;

  constructor(
    private _location: Location,
    private _router: Router,
  ) { }

  public ngOnInit(): void {
  }

  public back(): void {
    if(!this.url) {
      this._location.back(); // back usando el browser history
    } else {
      this._router.navigateByUrl(this.url); // back usando el router (puede que redireccionemos a otra pagina que no sea de la que venía el usuario)
    }
  }

}
