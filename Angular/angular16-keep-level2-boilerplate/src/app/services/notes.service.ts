import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable , of} from 'rxjs';
import { Note } from '../note';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class NotesService {
  constructor() {

  }

  getNotes(): Observable<Array<Note>> {
     // Mocked notes data
     return of([
      { id: 1, title: 'Read Angular 5 blog', text: 'Shall do at 6 pm' },
      { id: 2, title: 'Call Ravi', text: 'Track the new submissions' }
    ]);

  }

  addNote(note: Note): Observable<Note> {
    
    return of(note);
  }

}
