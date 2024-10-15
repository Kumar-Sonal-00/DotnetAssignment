import { Injectable } from '@angular/core';

import { Note } from './note';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
  private apiUrl = 'http://localhost:3000/notes';

  constructor(private httpClient: HttpClient) {}

  getNotes(): Observable<Array<Note>> {
    return this.httpClient
      .get<Note[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  addNote(note: Note): Observable<Note> {
    return this.httpClient
      .post<Note>(this.apiUrl, note)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
