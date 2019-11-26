import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css']
})
export class ClustersComponent implements OnInit {
  clustersRaw: string;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://group2table3.azurewebsites.net/api/clusters').subscribe((val) => {console.log('1'); console.log(val); console.log('2')});
  }

}
