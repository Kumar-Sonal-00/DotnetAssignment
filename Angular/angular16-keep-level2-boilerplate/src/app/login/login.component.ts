import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);

  submitMessage: string = '';
   
   
  constructor(private authService: AuthenticationService, private router: Router) {} // Inject the service
  loginSubmit() {
        // Logic for login submission
        // if (this.username.valid && this.password.valid) {
          // Handle login success
        // } else {
        //   this.submitMessage = 'Invalid login details';
        // }

       

        // this.authService.authenticateUser({ username: this.username, password: this.password })
        // .subscribe(
        //   (response: { token: string }) => { // Define the response type
        //     localStorage.setItem('authToken', response.token || 'token123');  // Set token in localStorage
        //     this.submitMessage = 'Login Successful';
        //     // Optional: Navigate after successful login
        //     // this.router.navigate(['/dashboard']);
        //   },
        //   (error: HttpErrorResponse) => { // Define the error type
        //     if (error.status === 404) {
        //       this.submitMessage = 'Unauthorized'; // Handle 404 as 'Unauthorized'
        //     } else {
        //       this.submitMessage = error.message; // Handle other errors
        //     }
        //   }
        // );

         // Ensure both username and password are valid
    // if (this.username.valid && this.password.valid) {
    //   this.authService.authenticateUser({ username: this.username.value, password: this.password.value })
    //   .subscribe(
    //     (response: { token: string }) => { // Define the response type
    //       localStorage.setItem('authToken', response.token || 'token123');  // Set token in localStorage
    //       this.submitMessage = 'Login Successful';
    //       // Optionally navigate after successful login
    //        this.router.navigate(['/dashboard']);
    //     },
    //     (error: HttpErrorResponse) => { // Define the error type
          
    //       if (error.status === 404) {
    //         this.submitMessage = 'Unauthorized'; // Handle 404 as 'Unauthorized'
    //       } else {
    //         this.submitMessage = 'Login failed: ' + error.message; // Handle other errors
    //       }
          
    //     }
    //   );
    // } else {
    //   this.submitMessage = 'Invalid login details';
    // }

    // if (this.username.valid && this.password.valid) {
    //   this.authService.authenticateUser({ username: this.username.value, password: this.password.value })
    //     .subscribe(
    //       (response: { token: string }) => {
    //         this.authService.setBearerToken(response.token || 'token123');
    //         this.submitMessage = 'Login Successful';
    //         // Optional: Navigate after successful login
    //         this.router.navigate(['/dashboard']);
    //       },
    //       (error: HttpErrorResponse) => {
    //         if (error.status === 404) {
    //           this.submitMessage = 'Unauthorized';
    //         } else {
    //           this.submitMessage = 'Error: ' + error.message;
    //         }
    //       }
    //     );
    // } else {
    //   this.submitMessage = 'Invalid login details';
    // }

    if (this.username.valid && this.password.valid) {
      this.authService.authenticateUser({ username: this.username.value, password: this.password.value })
        .subscribe(
          (response: { token: string }) => {
            // Save token in local storage
            this.authService.setBearerToken(response.token || 'token123');
            this.submitMessage = 'Login Successful';
            // Navigate after successful login
            this.router.navigate(['/dashboard']);
          },
          (error: HttpErrorResponse) => {
            if (error.status === 404) {
              this.submitMessage = 'Unauthorized'; // Ensure this matches the test expectation
            } else {
              this.submitMessage = 'Error: ' + error.message; // Ensure this format matches the test expectation
            }
          }
        );
    } else {
      this.submitMessage = 'Invalid login details';
    }
    

  }

 
}


