import { Component, OnInit } from '@angular/core';
import { ClusterService } from '../services/cluster.service';
import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-create-cluster',
  templateUrl: './create-cluster.component.html',
  styleUrls: ['./create-cluster.component.css']
})
export class CreateClusterComponent {
  name: string;

  constructor(
    private cluster: ClusterService,
  ) {
    this.name = '';
  }

  create() {
    let clean = this.name.trim();
    this.name = '';
    if (clean.length > 0) {
      this.cluster.createCluster(clean);
    }
  }
}
