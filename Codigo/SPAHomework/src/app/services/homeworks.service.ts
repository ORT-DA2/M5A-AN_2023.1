import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError, of, from } from "rxjs"; 
import { map, tap, catchError } from 'rxjs/operators';
import { IHomework } from "../models/IHomework";
import { Homework } from "../models/Homework";
import { Exercise } from "../models/Exercise";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class HomeworksService {
  private URL_HOMEWORK : string = environment.WEB_API_URL + '/homeworks';

  constructor(private _httpService: HttpClient) { }

  getHomeworks():Observable<Array<IHomework>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');    
    const httpOptions = {
        headers: myHeaders
    };
    return this._httpService.get<Array<IHomework>>(this.URL_HOMEWORK, httpOptions);
  }

  get(id: string): Observable<IHomework> {
    return this._httpService.get<IHomework>(this.URL_HOMEWORK + '/' + id, {});
  }

  create(homework: IHomework): Observable<IHomework> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/json');    
    const httpOptions = {
        headers: myHeaders
    };
    const body = homework;
    return this._httpService.post<IHomework>(this.URL_HOMEWORK, body, httpOptions);
  }

  private handleError(errorRequest: any) {
    console.error(errorRequest);
    return throwError(errorRequest.error || errorRequest.message);
  }
}
