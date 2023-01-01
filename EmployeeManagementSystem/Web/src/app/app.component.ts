// Defines the logic for the app's root component, named AppComponent. The view associated with this root component
// becomes the root of the view hierarchy as you add components and services to your app.

import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Accura Tech - Employee Management System';
}
