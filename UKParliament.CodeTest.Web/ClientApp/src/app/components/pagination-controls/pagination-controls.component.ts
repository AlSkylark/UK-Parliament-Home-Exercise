import { Component, Input, OnInit } from '@angular/core';
import { MPPaginatorModel } from 'src/models/mp-paginator-model';
import { MpPaginationComponent } from '../mp-pagination/mp-pagination.component';

@Component({
  selector: 'app-pagination-controls',
  templateUrl: './pagination-controls.component.html',
  styleUrls: ['./pagination-controls.component.scss']
})
export class PaginationControlsComponent implements OnInit {

  // @Input() decrease!: Function;
  // @Input() increase!: Function;
  // @Input() change!: Function;
  // @Input() pages!: number[];
  // @Input() paginator!: MPPaginatorModel;
  @Input() parent!: MpPaginationComponent;

  constructor() { }

  ngOnInit(): void {
  }

}
