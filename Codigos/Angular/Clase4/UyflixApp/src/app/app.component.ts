import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  public title = 'UyflixApp';
  public showMenu = true;
  private _routerSubscription$: Subscription | undefined;

  constructor(
    private _router: Router,
  ) { }

  public ngOnInit(): void {
      this._routerSubscription$ = this._router.events.subscribe((event) => {
        if(event instanceof NavigationEnd) {
          console.log({event});
          if(event.url.includes('admin')) {
            this.showMenu = false;
          } else {
            this.showMenu = true;
          }
        }
      });

  }

  public ngOnDestroy(): void {
      this._routerSubscription$?.unsubscribe();
  }
}
