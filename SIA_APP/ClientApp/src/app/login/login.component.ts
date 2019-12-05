import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  password: string;
  setRecently: number;

  constructor(
    private auth: AuthService,
  ) {
    this.password = '';
    this.setRecently = 0;
  }

  setPassword() {
    if (this.password.length > 0) {
      this.setRecently += 1;
      setTimeout(() => {
        this.setRecently -= 1;
      }, 5000);

      this.auth.password = this.password;
    }
  }
}
