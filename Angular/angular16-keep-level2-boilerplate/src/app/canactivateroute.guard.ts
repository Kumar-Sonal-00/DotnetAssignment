import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';
 

export const canactivaterouteGuard: CanActivateFn = (route, state) => {
   
 
   const authService = inject(AuthenticationService);
   const router = inject(Router);
 
   // Check if user is authenticated using the AuthenticationService
   const token = authService.getBearerToken();
 
   if (token) {
     // Assuming the `isUserAuthenticated` method verifies the token
     return authService.isUserAuthenticated(token).then((isAuthenticated) => {
       if (isAuthenticated) {
         return true;
       } else {
         router.navigate(['login']);  // Redirect to login if not authenticated
         return false;
       }
     });
   } else {
     router.navigate(['login']);  // No token, redirect to login
     return false;
   }
};
