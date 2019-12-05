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
    private clusterService: ClusterService
  ) {
    this.clusters = {};
  }

  ngOnInit() {
    this.clusters = this.clusterService.getClusters();
  }
}
