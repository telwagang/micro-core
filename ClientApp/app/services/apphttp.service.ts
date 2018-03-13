import { Injectable,Inject } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map,tap, catchError } from 'rxjs/Operators';


@Injectable()
export class AppHttpService {
   public url:string;
   
    httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
    constructor(private http: HttpClient,
    @Inject('BASE_URL') orginurl:string){
        this.url = orginurl + "api/"; 
    }

    get(url:string){
        return this.http.get(this.url+url, this.httpOptions)
      .pipe(tap(h => {
        const outcome = h ? `fetched` : `did not find`;
        this.log(`${outcome}`);
      }),
      catchError(this.handleError<any>(`get ${url}`)));
    }
    post(url:string, value:string){
        return this.http.post(this.url +url, value, this.httpOptions)
      .pipe(catchError(this.handleError<any>(`post ${url}, values ${value}`)))
      ;
    }
    private handleError<T> (operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
     
          // TODO: send the error to remote logging infrastructure
          console.error(error); // log to console instead
     
          // TODO: better job of transforming error for user consumption
          this.log(`${operation} failed: ${error.message}`);
     
          // Let the app keep running by returning an empty result.
          return of(result as T);
        };
      }
     
      /** Log a HeroService message with the MessageService */
      private log(message: string) {
        //this.messageService.add('HeroService: ' + message);
        console.log(message);
      }
}
