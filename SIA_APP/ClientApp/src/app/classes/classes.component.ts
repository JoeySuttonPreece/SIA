import { Component, OnInit } from '@angular/core';
import { ClassService } from '../services/class.service';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {
  classes: object;

  constructor(
    private classService: ClassService
  ) {
    this.classes = {};
  }

  ngOnInit() {
    this.classes = this.classService.getClasses();
  }
}
