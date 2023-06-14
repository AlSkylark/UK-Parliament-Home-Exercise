import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MPPaginatorModel } from 'src/models/mp-paginator-model';

@Component({
  selector: 'app-mp-manager',
  templateUrl: './mp-manager.component.html',
  styleUrls: ['./mp-manager.component.scss']
})
export class MpManagerComponent implements OnInit {

  paginator: MPPaginatorModel | undefined;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.GoToPage();
  }

  ngOnInit(): void {
  }

  GoToPage() {
    this.http.get<MPPaginatorModel>(this.baseUrl + `api/mp?page=1`)
      .subscribe(v => {
        this.paginator = v;
      });
  }

}
