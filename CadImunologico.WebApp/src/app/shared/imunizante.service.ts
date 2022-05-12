import { ErrorHandler, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Imunizante } from './imunizante';


@Injectable({
    providedIn: 'root'
})
export class ImunizanteService {

    constructor(private http: HttpClient) { }

    readonly baseURL = 'https://localhost:44395/api/Imunizantes'
    formData: Imunizante = new Imunizante();
    list: Imunizante[];
    tableData: any = [];

    getImunizante() {
        return this.http.get(this.baseURL)
        .pipe(
            retry(1),
            catchError(this.handleError)
        )
    }

    getImunizanteById() {
        return this.http.get<Imunizante>(`${this.baseURL}/${this.formData.Id}`)
        .pipe(
            retry(1),
            catchError(this.handleError)
        )
    }

    saveImunizante() {
        return this.http.post(this.baseURL, this.formData)
        .pipe(
            retry(1),
            catchError(this.handleError)
        )
    }

    updateImunizante() {
        return this.http.put(`${this.baseURL}/${this.formData.Id}`, this.formData)
        .pipe(
            retry(1),
            catchError(this.handleError)
        )
    }

    deleteImunizante(Id: number) {
        return this.http.delete(`${this.baseURL}/${Id}`)
        .pipe(
            retry(1),
            catchError(this.handleError)
        )
    }
    
    handleError(error: HttpErrorResponse) {
        let errorMessage = '';
        if(error.error instanceof ErrorEvent){
          errorMessage = error.error.message;
        } else {
          errorMessage = `Código do erro: ${error.status},` + `mensagem: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
      };

      refreshList() {
        this.http.get(this.baseURL)
        .toPromise()
        .then(res => {return this.tableData = res})
      }
}
