import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  constructor(private spinnerService: NgxSpinnerService) { }

  showSpinner(): void{
    this.spinnerService.show();
  }

  stopSpinner(): void{
    this.spinnerService.hide();
  }
}
