import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private loadingBehaviorSubject$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public get loading$(): Observable<boolean> {
    return this.loadingBehaviorSubject$.asObservable();
  }

  public showLoader() {
    this.loadingBehaviorSubject$.next(true);
  }

  public hideLoader() {
    this.loadingBehaviorSubject$.next(false);
  }
}
