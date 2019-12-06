import { Component, OnInit } from '@angular/core';
import { ClusterService } from '../services/cluster.service';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css']
})
export class ClustersComponent implements OnInit {
  clusters: object;

  constructor(
    private cluster: ClusterService
  ) {
    this.clusters = {};
  }

  ngOnInit() {
    this.clusters = this.cluster.getClusters();
  }

  delete(id: number) {
    console.log(id);

    this.cluster.deleteCluster(id);
  }
}
