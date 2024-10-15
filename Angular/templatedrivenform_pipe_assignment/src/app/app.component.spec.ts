import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user.service';
import { FormsModule } from '@angular/forms';
import { SearchPipe } from './pipe/search.pipe';

describe('AppComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [AppComponent,ContactComponent,SearchPipe],
    imports:[ HttpClientModule,FormsModule],
    providers:[UserService]
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });


});
