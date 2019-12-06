import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassService } from '../services/class.service';
import { ScanService } from '../services/scan.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
  class;
  scans;

  constructor(
    private clusterService: ClassService,
    private scanService : ScanService,
    private route: ActivatedRoute
  ) {
    this.class = { cluster: { name: "loading" } };
    this.scans = [];
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.clusterService.getClass(params.id).then((val) => {
        this.class = val;
        console.log(val);
        this.scanService .getScansForClass(this.class.classID).then((val) => {
          this.scans = val
          console.log(val)
        });
      });
    });
  }
}
