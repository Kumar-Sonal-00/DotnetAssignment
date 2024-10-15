import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../model/Contact';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  // build a logic to search for contacts based on name or mobile number

  transform(contacts: Contact[], searchText: string): Contact[] {
    if (!contacts || !searchText) {
      return contacts;
    }
    searchText = searchText.toLowerCase();
    return contacts.filter(contact =>
      (contact.name && contact.name.toLowerCase().includes(searchText)) ||
      (contact.mobile && contact.mobile.toString().includes(searchText))
    );
  }
  // transform(value: unknown, ...args: unknown[]): unknown {
  //   return null;
  // }

}
