import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderComponent } from './header.component';
import { MatToolbarModule } from "@angular/material/toolbar";
import { By } from '@angular/platform-browser';


describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;
  let debugElement: any;
  let element: any;


  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderComponent],
      imports:[
        MatToolbarModule
      ]
    });
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  
  it('should handle to Check header a title', () => {
    const debugElement = fixture.debugElement.query(By.css('.mat-toolbar'));
    if (debugElement) {
      element = fixture.debugElement.query(By.css('.mat-toolbar')).nativeElement;
      expect(element.textContent).toBe('Keep', 'title is not matching');
    }
    else {
      expect(false).toBe(true, 'header is not present');
    }
  });


});
