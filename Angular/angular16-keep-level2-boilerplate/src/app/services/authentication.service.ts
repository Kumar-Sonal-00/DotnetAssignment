import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { filter, map, Observable } from 'rxjs';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  // private apiUrl = 'http://localhost:3000/users';
  private apiUrl = 'http://localhost:3000/auth/v1';
  
  constructor(private httpClient: HttpClient) { }

  
  authenticateUser(data: any): Observable<any> {
    // return this.httpClient.post('/api/authenticate', data);
    // return this.httpClient.post(`${this.apiUrl}/authenticate`, data);  

    return this.httpClient.get<any[]>(this.apiUrl).pipe(
      map(users => {
        const user = users.find(u => u.username === data.username && u.password === data.password);
        if (user) {
          return { token: user.token };
        } else {
          throw new Error('Unauthorized');
        }
      })
    );
  }

  setBearerToken(token:string) {
    localStorage.setItem('token', token);

  }

  getBearerToken() {
    return localStorage.getItem('token');

  }

  isUserAuthenticated(token:string): Promise<boolean> {
    return new Promise((resolve) => {
      // Implement JWT token verification
      resolve(true);
    });

  }

}
