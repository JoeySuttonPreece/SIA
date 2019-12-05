import { Component, OnInit } from '@angular/core';
import { ClusterService } from '../services/cluster.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cluster',
  templateUrl: './cluster.component.html',
  styleUrls: ['./cluster.component.css']
})
export class ClusterComponent implements OnInit {
  cluster;

  constructor(
    private clusterService: ClusterService,
    private route: ActivatedRoute
  ) {
    this.cluster = {name: "Loading"};
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.clusterService.getCluster(params.id).then((val) => this.cluster = val);
    });
  }
}
