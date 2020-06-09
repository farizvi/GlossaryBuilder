import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import {IGlossary} from '../models/glossary.model';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {INewTerm} from '../models/newterm.model';
import {IEditTerm} from "../models/editterm.model";

@Injectable({
  providedIn: 'root'
})
export class GlossaryService {
  baseUrl: string = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private http: HttpClient
  ) { }

  getGlossaryTerms(): Observable<IGlossary[]>  {
    return this.http.get<IGlossary[]>(this.baseUrl);
  }

  getGlossaryTerm(id: number): Observable<IGlossary> {
    return this.http.get<IGlossary>(`${this.baseUrl}/${id}`);
  }

  saveGlossaryTerm(term: INewTerm) {
    return this.http.post(this.baseUrl, term, this.httpOptions);
  }

  updateGlossaryTerm(id: number, term: IEditTerm) {
    return this.http.put(`${this.baseUrl}/${id}`, term, this.httpOptions);
  }

  deleteTerm(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
