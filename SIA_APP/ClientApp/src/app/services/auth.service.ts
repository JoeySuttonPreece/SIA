import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  password: string
  constructor() {
    this.password = 'password';
  }

  authObj() {
    return { params: { secret: this.password } }
  }
}
