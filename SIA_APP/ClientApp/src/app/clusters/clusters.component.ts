import { Component, OnInit } from '@angular/core';
import { ClusterService } from '../services/cluster.service';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css']
})
export class ClustersComponent implements OnInit {
  clusters;

  constructor(
    private clusterService: ClusterService
  ) { }

  ngOnInit() {
    this.clusters = this.clusterService.getClusters();
  }
}
