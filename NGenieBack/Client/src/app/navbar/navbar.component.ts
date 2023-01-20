import { Component } from '@angular/core';

interface User {
  image:string
}


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  user: User | null = {
    image:'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/1024px-Cat03.jpg'
  };
  // user: User | null = null; */
}
