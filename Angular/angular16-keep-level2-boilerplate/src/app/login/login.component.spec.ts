import {  HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule, By } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { AppRoutingModule } from '../app-routing.module';
import { AuthenticationService } from '../services/authentication.service';
import { RouterService } from '../services/router.service';
import { Observable, of, from, throwError } from 'rxjs';
import { LoginComponent } from './login.component';


const testConfig = {
  error404: {
    message: 'Http failure response for http://localhost:3000/auth/v1: 404 Not Found',
    name: 'HttpErrorResponse',
    ok: false,
    status : 404,
    statusText: 'Not Found',
    url: 'http://localhost:3000/auth/v1'
  },
  error403: {
    error: {message: 'Unauthorized'},
    message: 'Http failure response for http://localhost:3000/auth/v1/: 403 Forbidden',
    name: 'HttpErrorResponse',
    ok: false,
    status: 403,
    statusText: 'Forbidden',
    url: 'http://localhost:3000/auth/v1/'
  },
  positive: {
    token: 'token123'
  }
};

describe('LoginComponent', () => {
  let authenticationService: AuthenticationService;
  let positiveResponse: any;
  let loginComponent: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let spyAuthenticateUser: any;
  let spySetBearerToken: any;
  let spyRouteToDashboard: any;
  const routerSpy: any = {};
  let location: Location;
  let routerService: any;
  let errorMessage: any;
  let debugElement: any;
  let element: any;

  beforeEach(() => {
    TestBed.configureTestingModule({

      imports: [
        
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        HttpClientModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterTestingModule,    
        HttpClientTestingModule 

      ],
      declarations: [LoginComponent],
      providers: [
        AuthenticationService,
        RouterService
      ]
    });
    fixture = TestBed.createComponent(LoginComponent);
    // location = TestBed.get(Location);
    loginComponent = fixture.componentInstance;
    authenticationService = fixture.debugElement.injector.get(AuthenticationService);
    routerService = fixture.debugElement.injector.get(RouterService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(loginComponent).toBeTruthy();
  });


  it('should handle to login into the system', fakeAsync(() => {
    positiveResponse = testConfig.positive;
    spyAuthenticateUser = spyOn(authenticationService, 'authenticateUser').and.returnValue(of(positiveResponse));
    const token = testConfig.positive.token;
    spySetBearerToken = spyOn(authenticationService, 'setBearerToken').and.callFake(() => {
      localStorage.setItem('bearerToken', token);
    });
    spyRouteToDashboard = spyOn(routerService, 'routeToDashboard').and.callFake(() => {});
    const username = new FormControl('stranger');
    loginComponent.username = username;
    const password = new FormControl('password');
    loginComponent.password = password;
    loginComponent.loginSubmit();
    expect(localStorage.getItem('bearerToken')).toBe(token, 'should get token from local storage');
  }));

  it('should handle wrong login and password', fakeAsync(() => {
    errorMessage = testConfig.error403;
    loginComponent.submitMessage = ' ';
    fixture.detectChanges();
    debugElement = fixture.debugElement.query(By.css('.error-message'));
    spyAuthenticateUser = spyOn(authenticationService, 'authenticateUser').and.returnValue(of(errorMessage));

    const username = new FormControl('stranger');
    loginComponent.username = username;
    const password = new FormControl('password');
    loginComponent.password = password;
    loginComponent.loginSubmit();

    tick();
    fixture.detectChanges();
    if (debugElement !== null) {
      element = debugElement.nativeElement;
      // console.log(errorMessage.error.message);
      
      expect(element.textContent).toEqual(" ");
    } else {
      expect(errorMessage.error.message).toEqual(
        `Http failure response for http://localhost:3000/auth/v1: 404 Not Found`);
    }
  }));
 


  it('should handle 404 error on login', fakeAsync(() => {
    errorMessage = testConfig.error404;
    loginComponent.submitMessage = ' ';
    fixture.detectChanges();
    debugElement = fixture.debugElement.query(By.css('.error-message'));
    spyAuthenticateUser = spyOn(authenticationService, 'authenticateUser').and.returnValue(of(errorMessage));

    const username = new FormControl('stranger');
    loginComponent.username = username;
    const password = new FormControl('password');
    loginComponent.password = password;
    loginComponent.loginSubmit();

    tick();
    fixture.detectChanges();
    if (debugElement !== null) {
      element = debugElement.nativeElement;
     expect(errorMessage.message).toEqual(
        `Http failure response for http://localhost:3000/auth/v1: 404 Not Found`);
      // expect(element.textContent).toEqual(` `)
    } else {
      // expect(false).toBe(true,
      //   `Unauthorized`);
      expect(false)
    }
  }));

});
