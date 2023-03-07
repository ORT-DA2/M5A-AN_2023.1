import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError, of } from "rxjs"; 
import { map, tap, catchError } from 'rxjs/operators';
import { Homework } from '../models/Homework';
import { Exercise } from '../models/Exercise';

@Injectable()
export class HomeworksService {

  private WEB_API_URL : string = 'http://localhost:5000/api/homeworks';

  constructor(private _httpService: HttpClient) {  }
  
  getHomeworks():Observable<Array<Homework>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');    
    const httpOptions = {
        headers: myHeaders
    };
    const homeworks : Array<Homework> = [
      new Homework("1", "Tarea 1", 1, new Date(), [], 1),
      new Homework("2", "Tarea 2", 1, new Date(), [new Exercise("1", "2 + 2 = 1", 3)], 5),
    ];
    //return this._httpService.get<Array<Homework>>(this.WEB_API_URL, httpOptions)
    //      .pipe(tap(x => console.log(x)), catchError(this.handleError));  
    return of(homeworks);
  }

  private handleError(errorRequest: any) {
    console.error(errorRequest);
    return throwError(errorRequest.error || errorRequest.message);
  }
  
}