import { Component } from '@angular/core';

@Component({
  selector: 'app-post-details',
  standalone: true,
  imports: [],
  templateUrl: './post-details.component.html',
  styleUrl: './post-details.component.css'
})
export class PostDetailsComponent {
  // heading: string = "Angular component creation for post page";
  title: string = "Robotics";
  author: string = "Zack Whittake";
  postedDate: string = "01/10/2019";
  category: string = "Robotics";
  likes: number = 27;
  
}
