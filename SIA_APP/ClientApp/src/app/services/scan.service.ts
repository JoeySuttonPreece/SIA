import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ScanService {
  constructor(
    private http: HttpClient,
    private auth: AuthService,
  ) { }

  getScansForClass(id) {
    return this.http.get('api/scans/class/' + id, this.auth.authObj()).toPromise();
  }
}
