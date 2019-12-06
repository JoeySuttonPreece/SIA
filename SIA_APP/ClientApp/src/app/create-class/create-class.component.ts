import { Component, OnInit, Input } from '@angular/core';
import { ClassService } from '../services/class.service';

@Component({
  selector: 'app-create-class',
  templateUrl: './create-class.component.html',
  styleUrls: ['./create-class.component.css']
})
export class CreateClassComponent {
  @Input() iD: number;
  day: string;
  startTime: string;
  endTime: string;

  constructor(
    private classService: ClassService,
  ) {
    this.day = '';
    this.startTime = '';
    this.endTime = '';
  }

  create() {
    console.log(this.iD, this.day, this.startTime, this.endTime);

    this.classService.createClass(this.iD, this.day, this.startTime, this.endTime);
  }
}
