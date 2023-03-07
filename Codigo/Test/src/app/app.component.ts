import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'visible';
  title2 = 'visible2';

  alert1() {
    alert("hola");
  }
}
