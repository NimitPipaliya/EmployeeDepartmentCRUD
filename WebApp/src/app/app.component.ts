import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './Shared/footer/footer.component';
import { NavbarComponent } from './Shared/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet,NavbarComponent,FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WebApp';
}