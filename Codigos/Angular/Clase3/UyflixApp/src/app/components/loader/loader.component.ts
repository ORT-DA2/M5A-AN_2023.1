import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingService } from '../../services/loading.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit, OnDestroy {
  @Input() public isLoading = false;

  private _loadingSubscription$: Subscription | undefined;
  
  constructor(private loadingScreenService: LoadingService) { }

  public ngOnInit(): void {
    this._loadingSubscription$ = this.loadingScreenService.loading$
    .subscribe((loading: boolean) => this.isLoading = loading);
  }

  public ngOnDestroy(): void {
      this._loadingSubscription$?.unsubscribe();
  }
}
