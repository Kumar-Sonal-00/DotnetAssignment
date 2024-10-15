import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../model/Contact';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'http://localhost:3000/contacts';  
  constructor(private http: HttpClient) { }


   // Implement addContacts method using HttpClient for saving a Contacts details
   addContact(contact:any): Observable<any> {
    return this.http.post<Contact>(this.apiUrl, contact);

  }

  // Implement getAllContactss method using HttpClient for getting all Contacts details
  getAllContacts(): Observable<any> {
    return this.http.get<Contact[]>(this.apiUrl);

  }
  
}
