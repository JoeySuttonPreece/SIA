import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassService } from '../services/class.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
  class;

  constructor(
    private clusterService: ClassService,
    private route: ActivatedRoute
  ) {
    this.class = {name: "Loading"};
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.clusterService.getClass(params.id).then((val) => this.class = val);
    });
  }
}
