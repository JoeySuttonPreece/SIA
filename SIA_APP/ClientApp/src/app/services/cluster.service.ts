import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ClusterService {
  private clusters: BehaviorSubject<any>;

  constructor(
    private http: HttpClient,
    private auth: AuthService,
  ) {
    this.clusters = new BehaviorSubject([]);
  }

  updateClusters() {
    this.http.get('api/clusters', this.auth.authObj())
      .toPromise()
      .then((val) => this.clusters.next(val))
      .catch((error) => {
        console.log(error);
        this.clusters.next([]);
      });
  }

  getClusters() {
    this.updateClusters();
    return this.clusters;
  }

  getCluster(id: number) {
    return this.http.get('api/cluster/' + id, this.auth.authObj()).toPromise();
  }

  createCluster(name: string) {
    this.http.post('api/cluster/', { name: name }, this.auth.authObj())
    .toPromise()
    .then((value) => this.updateClusters())
    .catch((error) => console.log(error));
  }

  deleteCluster(id: number) {
    this.http.delete('api/cluster/' + id, this.auth.authObj())
    .toPromise()
    .then((value) => this.updateClusters())
    .catch((error) => console.log(error));
  }
}
