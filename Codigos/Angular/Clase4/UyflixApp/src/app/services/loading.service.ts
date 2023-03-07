import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  public loading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor() { }

  public startLoading() {
    this.loading$.next(true);
  }

  public stopLoading() {
    this.loading$.next(false);
  }
}
