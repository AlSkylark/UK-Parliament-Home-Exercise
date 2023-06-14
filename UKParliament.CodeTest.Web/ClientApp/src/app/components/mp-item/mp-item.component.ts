import { Component, Input, OnInit } from '@angular/core';
import { MPViewModel } from 'src/models/mp-view-model';

@Component({
  selector: 'app-mp-item',
  templateUrl: './mp-item.component.html',
  styleUrls: ['./mp-item.component.scss']
})
export class MpItemComponent implements OnInit {

  @Input() mp!: MPViewModel;
  constructor() { }

  ngOnInit(): void {
  }

}
