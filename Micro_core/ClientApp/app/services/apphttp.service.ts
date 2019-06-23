import { MicroResponse } from './../models/micro-response';
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
        return this.http.get<MicroResponse>(this.url+url, this.httpOptions)
      .pipe(tap(h => {
        const outcome = h ? `fetched` : `did not find`;
        this.log(`${outcome}`);
      }),
      catchError(this.handleError<any>(`get ${url}`)));
    }
    post(url:string, value:any){
        return this.http.post<MicroResponse>(this.url +url, value, this.httpOptions)
      .pipe(
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome}`);
        }),catchError(this.handleError<any>(`post ${url}, values ${value}`)))
      ;
    }
    private handleError<MicroResponse> (operation = 'operation', result?: MicroResponse) {
        return (error: any): Observable<MicroResponse> => {
     
          // TODO: send the error to remote logging infrastructure
           // log to console instead
     
          // TODO: better job of transforming error for user consumption
          this.log(`${operation} failed: ${error.Message}`);
          this.log(error); 
          // Let the app keep running by returning an empty result.
          return of(error);
        };
      }
     
      /** Log a HeroService message with the MessageService */
      private log(message: string) {
        //this.messageService.add('HeroService: ' + message);
        console.log(message);
      }
}
