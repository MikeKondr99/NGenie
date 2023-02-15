import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  host: {
    class: 'flex h-full'
  }
})
export class AppComponent {
  isCollapsed = false;
}
