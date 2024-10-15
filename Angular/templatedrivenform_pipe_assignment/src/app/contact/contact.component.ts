import { Component } from '@angular/core';
import { Contact } from '../model/Contact';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
 // form conatins the name of the Contact and mobile number
 
 form: any = {
  name: '',
  mobile: ''
};
 // contacts is to store all Contacts data
 contacts: Contact[] = [];
 // message is to  be displayed
 message:string="";
 
 searchText:string="";
 
 // isContactedAdded is for validating contact is added or not
 isContactedAdded:boolean=false;
 constructor(private userservice: UserService) {}
 // Call UserService and use getAllContacts method to get Contacts data
   ngOnInit() {
     this.getAllContacts();
   }
   getAllContacts() {
    this.userservice.getAllContacts().subscribe(
      (data: Contact[]) => {
        this.contacts = data;
      },
      (error) => {
        console.error('Error fetching contacts', error);
      }
    );
  }
   // Write logic to add a Contact by using addContact method of UserService
   // Display message 'Contact already exists' if already a contact exists with same mobile number
   // Display message 'Failed to add Contact' while error handling
   // Display message 'Contact Added' if contact is added
   onSubmit() {
    const existingContact = this.contacts.find(c => c.mobile === this.form.mobile);
    if (existingContact) {
      this.message = 'Contact already exists';
      return;
   }


   this.userservice.addContact(this.form).subscribe(
    () => {
      this.isContactedAdded = true;
      this.message = 'Contact added';
      this.getAllContacts(); // Refresh the list after adding
    },
    (error) => {
      this.message = 'Failed to add Contact';
      console.error(error);
    }
  );
}}