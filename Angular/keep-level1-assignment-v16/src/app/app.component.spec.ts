import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule, By } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable, of, from, throwError } from 'rxjs';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NotesService } from './notes.service';

// Fake Dat
const testConfig = {
  getNotes: {
    positive: [
      {
        title: 'Read Angular 5 blog',
        text: 'Shall do at 6 pm'
      },
      {
        title: 'Call Ravi',
        text: 'Track the new submissions'
      }
    ],
    negative: []
  },
  addNotes: {
    positive: {
      title: 'Read Angular 5 blog again',
      text: 'Shall do at 7 pm'
    },
    negative: {},
    errorMessage: 'Title and Text both are required fields'
  },
  error404: {
    message:
      'Http failure response for http://localhost:3000/notes: 404 Not Found',
    name: 'HttpErrorResponse',
    ok: false,
    status: 404,
    statusText: 'Not Found',
    url: 'http://localhost:3000/notes'
  }
};

describe('AppComponent', () => {

  let fixture: ComponentFixture<AppComponent>;
  let notesService: NotesService;
  let spyGetNotes: any;
  let spyTakeNotes: any;
  let appComponent: AppComponent;
  let errorResponse404: any;
  let positiveResponse: Array<any>;
  let negativeResponse: Array<any>;
  let errorMessage: string;
  let addNotesPositiveResponse: any;
  let debugElement: any;
  let element: any;
  let doneButton: any;
  let inputBox: any;
  let textArea: any;



  beforeEach(async () => TestBed.configureTestingModule({
    imports: [
      RouterTestingModule,
      BrowserModule,
      BrowserAnimationsModule,
      MatToolbarModule,
      MatCardModule,
      MatExpansionModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule,
      FormsModule,
      HttpClientModule

    ],
    declarations: [AppComponent, HeaderComponent],
    providers: [NotesService]

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    appComponent = fixture.componentInstance;
    notesService = fixture.debugElement.injector.get(NotesService);
  });

  // Should create the app Componnet

  it('should create the app', async () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  // Should handle 404 Error on get Notes

  it('should handle 404 Error on get Notes', fakeAsync(() => {

    errorMessage = testConfig.error404.message;
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(throwError(testConfig.error404));
    fixture.detectChanges();
    tick();
    debugElement = fixture.debugElement.query(By.css('.error-message'));
    if (debugElement) {
      element = debugElement.nativeElement;
      expect(element.textContent).toBe(errorMessage, 'should handle 404 error');


    }
    else {
      expect(false).toBe(true, 'should handle 404 error');
    }

  }));
  // should get all Notes

  it('should handle to Get all Notes', fakeAsync(() => {
    positiveResponse = testConfig.getNotes.positive;
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(of(positiveResponse));
    fixture.detectChanges();
    tick();
    debugElement = fixture.debugElement.query(By.css('.mat-card-title'));
    if (debugElement) {
      element = debugElement.nativeElement;
      expect(element.textContent).toBe(positiveResponse[0].title);
    }
    else {
      expect(false).toBe(false);
    }

  }));

  //Should handle 404 on add Note

  it('should handle 404 on add Note', fakeAsync(() => {
    errorResponse404 = testConfig.error404;
    positiveResponse = testConfig.getNotes.positive;
    doneButton = fixture.debugElement.nativeElement.querySelector('button');
    inputBox = fixture.debugElement.nativeElement.querySelector('input');
    textArea = fixture.debugElement.nativeElement.querySelector('textarea');
    debugElement = fixture.debugElement.query(By.css('.error-message'));

    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(of(positiveResponse));

    spyTakeNotes = spyOn(notesService, 'addNote').and.returnValue(throwError(errorResponse404));
    fixture.detectChanges();
    tick();
    if (
      inputBox !== null &&
      textArea !== null &&
      doneButton !== null &&
      debugElement !== null
    ) {
      inputBox.value = testConfig.addNotes.positive.title;
      inputBox.dispatchEvent(new Event('input'));
      textArea.value = testConfig.addNotes.positive.text;
      textArea.dispatchEvent(new Event('input'));
      doneButton.click();
      tick();
      fixture.detectChanges();
      element = debugElement.nativeElement;
      expect(element.textContent).toBe(
        errorResponse404.message)
    } else {
      expect(false).toBe(
        true);
    }
  }));

  // should handle empty field

  it('should handle blank fields', fakeAsync(() => {
    errorMessage = testConfig.addNotes.errorMessage;
    positiveResponse = testConfig.getNotes.positive;
    doneButton = fixture.debugElement.nativeElement.querySelector('button');
    debugElement = fixture.debugElement.query(By.css('.error-message'));
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(
      of(positiveResponse)
    );
    spyTakeNotes = spyOn(notesService, 'addNote').and.returnValue(throwError(errorMessage)
    );
    fixture.detectChanges();
    if (doneButton !== null && debugElement !== null) {
      doneButton.click();
      tick();
      fixture.detectChanges();
      element = debugElement.nativeElement;
      expect(element.textContent).toBe(
        errorMessage
      );
    } else {
      expect(false).toBe(
        true
      );
    }
  }));

it('should handle to add a note', fakeAsync(() => {
    positiveResponse = testConfig.getNotes.positive;
    addNotesPositiveResponse = testConfig.addNotes.positive;
    doneButton = fixture.debugElement.nativeElement.querySelector('button');
    inputBox = fixture.debugElement.nativeElement.querySelector('input');
    textArea = fixture.debugElement.nativeElement.querySelector('textarea');
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(
      of(positiveResponse)
    );
    spyTakeNotes = spyOn(notesService, 'addNote').and.returnValue(
      of(addNotesPositiveResponse)
    );
    fixture.detectChanges();
    tick();
    if (inputBox !== null && textArea !== null && doneButton !== null) {
      inputBox.value = testConfig.addNotes.positive.title;
      textArea.value = testConfig.addNotes.positive.text;
      inputBox.dispatchEvent(new Event('input'));
      textArea.dispatchEvent(new Event('input'));
      doneButton.click();
      tick();
      fixture.detectChanges();
      debugElement = fixture.debugElement.queryAll(By.css('.mat-card-title'));
      if (debugElement.length > 0) {
        const lastIndex = debugElement.length - 1;
        element = debugElement[lastIndex].nativeElement;
        expect(element.textContent).toBe(
          addNotesPositiveResponse.title,
          `should validate newly created note is visible on view into the <mat-card-title>`
        );
      } else {
        expect(false).toBe(
          false       
        );
      }
    } else {
      expect(false).toBe(
      false
      );
    }
  }));

});
