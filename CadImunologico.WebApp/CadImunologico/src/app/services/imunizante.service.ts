import { ErrorHandler, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Imunizante } from '../models/imunizante';

@Injectable({
    providedIn: 'root'
})

export class ImunizanteService {
    url = 'https://localhost:44395/api/Imunizantes'


constructor(private httpClient : HttpClient) { }

httpOptions = {
    headers: new HttpHeaders({ 'Content-type' : 'application/json'})
}

getImunizante() : Observable<Imunizante[]>{
    return this.httpClient.get<Imunizante[]>(this.url)
    .pipe(
        retry(2),
        catchError(this.handleError))
}

getImunizanteById(Id : number) : Observable<Imunizante>{
    return this.httpClient.get<Imunizante>(this.url + '/' + Id)
    .pipe(
        retry(2),
        catchError(this.handleError))
}

saveImunizante(imunizante : Imunizante) : Observable<Imunizante>{
    return this.httpClient.post<Imunizante>(this.url, JSON.stringify(imunizante), this.httpOptions)
    .pipe(
        retry(1),
        catchError(this.handleError))
}

updateImunizante(imunizante : Imunizante) : Observable<Imunizante>{
    return this.httpClient.post<Imunizante>(this.url + '/' + imunizante.Id, JSON.stringify(imunizante), this.httpOptions)
    .pipe(
        retry(1),
        catchError(this.handleError))
}

deleteImunizante(imunizante : Imunizante){
    return this.httpClient.delete<Imunizante>(this.url + '/' + imunizante.Id, this.httpOptions)
    .pipe(
        retry(1),
        catchError(this.handleError))
}


handleError(error : HttpErrorResponse) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    } else {
      errorMessage = `Código do erro: ${error.status},` + `mensagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}