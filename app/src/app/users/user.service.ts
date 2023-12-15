import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from 'rxjs/operators';
import { IUser } from "./user";

@Injectable({
    providedIn: 'root'
  })
  export class UserService {
    private productUrl = 'https://localhost:7023/api/MeterRead/user'
    constructor(private http: HttpClient) { }

    getUsers(): Observable<IUser[]> {
        return this.http.get<IUser[]>(this.productUrl)
          .pipe(
            tap(data => console.log('All: ', JSON.stringify(data))),
            catchError(this.handleError)
          );
    }    

    private handleError(err: HttpErrorResponse): Observable<never> {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(() => errorMessage);
      }    
  }