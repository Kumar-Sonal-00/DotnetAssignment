import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PostDetailsComponent } from './post-details/post-details.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,PostDetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Display-Post-Details';
}
