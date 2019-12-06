import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ClassService {
  private classes: BehaviorSubject<any>;

  constructor(
    private http: HttpClient,
    private auth: AuthService,
  ) {
    this.classes = new BehaviorSubject([]);
  }

  updateClasses() {
    this.http.get('api/classes', this.auth.authObj())
      .toPromise()
      .then((val) => this.classes.next(val))
      .catch((error) => {
        console.log(error);
        this.classes.next([]);
      });
  }

  getClasses() {
    this.updateClasses();
    return this.classes;
  }

  getClass(id: number) {
    return this.http.get('api/class/' + id, this.auth.authObj()).toPromise();
  }

  createClass(clusterID: number, day: string, startTime: string, endTime: string) {
    this.http.post('api/class/', { clusterID, day, startTime, endTime }, this.auth.authObj())
    .toPromise()
    .then((value) => this.updateClasses())
    .catch((error) => console.log(error));
  }

  deleteClass(id: number) {
    this.http.delete('api/class/' + id, this.auth.authObj())
    .toPromise()
    .then((value) => this.updateClasses())
    .catch((error) => console.log(error));
  }
}
