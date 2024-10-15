import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, fakeAsync, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthenticationService } from '../services/authentication.service';
import { NotesService } from '../services/notes.service';
import { Observable, of, from, throwError } from 'rxjs';
import { DashboardComponent } from './dashboard.component';

const testConfig = {
  getNotes: {
    positive: [{
      id: 1,
      title: 'Read Angular 5 blog',
      text: 'Shall do at 6 pm',
      state: 'not-started'
    },
    {
      id: 2,
      title: 'Call Ravi',
      text: 'Track the new submissions',
      state: 'not-started'
    }],
    negative: []
  }
};


describe('DashboardComponent', () => {

  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let notesService: NotesService;
  let spyGetNotes: any;
  let positiveResponse: Array<any>;
  let negativeResponse: Array<any>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DashboardComponent],
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
        HttpClientTestingModule 
      ],
      providers: [
        AuthenticationService,
        NotesService
      ]
    });
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  
  beforeEach(()=>{
    notesService= TestBed.inject(NotesService);
  })

  it('should create', () => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should handle to get all notes', fakeAsync(() => {
    positiveResponse = testConfig.getNotes.positive;
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(of(positiveResponse));
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    expect(component.notes).toBe(positiveResponse, `should get all notes from back end`);
  }));

  it('should handle if no note is created by user', fakeAsync(() => {
    negativeResponse = testConfig.getNotes.negative;
    spyGetNotes = spyOn(notesService, 'getNotes').and.returnValue(of(negativeResponse));
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    expect(component.notes.length).toBe(0,
      `If there is no 'note' created, notes array length should be 0`);
  }));

});
