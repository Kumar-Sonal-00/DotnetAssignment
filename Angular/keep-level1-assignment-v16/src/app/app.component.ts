import { Component } from '@angular/core';
import { Note } from './note';
import { NotesService } from './notes.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[NotesService]
})
export class AppComponent {
  note: Note = new Note();
  notes: Array<Note> = [];
  errMessage: string="";
  // noteTitle: string = '';
  // noteText: string = '';

  constructor(private notesService: NotesService) {}

  ngOnInit() {
    this.getNotes();
  // this.loadNotes()
  }

  addNote() {
    if (!this.note.title || !this.note.text) {
      this.errMessage = 'Title and Text both are required fields';
      return;
    }
    
    this.notesService.addNote(this.note).subscribe({
      next: (response) => {
        this.notes.push(response);
      
        this.errMessage = '';
      },
      error: (error) => {
        if (error.status === 404) {
          this.errMessage = 'Http failure response for http://localhost:3000/notes: 404 Not Found';
        } else {
          this.errMessage = 'Failed to add note';
        }
      }
    });
  }
  getNotes() {
    this.notesService.getNotes().subscribe({
      next: (response) => {
        this.notes = response;
        this.errMessage = ''; // Clear error message on successful response
      },
      error: (error) => {
        if (error.status === 404) {
          this.errMessage = 'Http failure response for http://localhost:3000/notes: 404 Not Found';
        } else {
          this.errMessage = 'Failed to load notes';
        }
      }
    });
  }
 



}