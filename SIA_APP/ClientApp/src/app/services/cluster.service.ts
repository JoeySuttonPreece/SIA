import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ClusterService {
  private clusters: BehaviorSubject<any>
  constructor(
    private http: HttpClient
  ) {
    this.clusters = new BehaviorSubject([]);
  }

  updateClusters() {
    this.http.get('api/clusters').toPromise().then((val) => this.clusters.next(val));
  }

  getClusters() {
    this.updateClusters();
    return this.clusters;
  }

  getCluster(id: number) {
    return this.http.get('api/cluster/' + id).toPromise();
  }
}
