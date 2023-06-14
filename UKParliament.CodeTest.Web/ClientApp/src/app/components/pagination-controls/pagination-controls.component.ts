import { Component, Input, OnInit } from '@angular/core';
import { MpPaginationComponent } from '../mp-pagination/mp-pagination.component';

@Component({
  selector: 'app-pagination-controls',
  templateUrl: './pagination-controls.component.html',
  styleUrls: ['./pagination-controls.component.scss']
})
export class PaginationControlsComponent implements OnInit {

  @Input() parent!: MpPaginationComponent

  constructor() { }
  ngOnInit(): void {

  }
}
