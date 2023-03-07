import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { User } from '../types';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  user: User | undefined;
  constructor (private auth:AuthService,private router: Router) {}


  public async ngOnInit() {
    this.user = await this.auth.get_user();
  }

  public async logout() {
    localStorage.setItem('token',"");
    window.location.reload();
  }
}
