import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

  product: any[] = [
    { name: 'Cone', price: '$10', image: 'https://sugarpursuit.com/wp-content/uploads/2023/05/Vanilla-bean-ice-cream.jpg', stock: '200' },
    { name: 'Brighams', price: '$20', image: 'https://bakeorbreak.com/wp-content/uploads/2020/07/chocolate_brownie_ice_cream04011k.jpg', stock: '0' },
    { name: 'Milkshake', price: '$30', image: 'https://www.thebigsweettooth.com/wp-content/uploads/2018/03/7.-Strawberry-Swirl-Ice-Cream2-550x825.jpg', stock: '500' },
    { name: 'Squeeze', price: '$40', image: 'https://www.browneyedbaker.com/wp-content/uploads/2020/06/Mint-chocolate-chip-ice-cream-11-1200-1024x1536.jpg', stock: '100' }
  
];
}
