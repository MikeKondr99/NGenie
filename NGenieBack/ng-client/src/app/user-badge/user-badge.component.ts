import { Component, Input } from '@angular/core';
import { User } from '../types';

@Component({
  selector: 'app-user-badge',
  templateUrl: './user-badge.component.html',
  styleUrls: ['./user-badge.component.css']
})
export class UserBadgeComponent {

  @Input()
  declare user: User 
}
