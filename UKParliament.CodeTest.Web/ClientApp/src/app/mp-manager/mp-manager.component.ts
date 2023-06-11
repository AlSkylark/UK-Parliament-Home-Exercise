import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MPPaginatorModel } from 'src/models/mp-paginator-model';

@Component({
  selector: 'app-mp-manager',
  templateUrl: './mp-manager.component.html',
  styleUrls: ['./mp-manager.component.scss']
})
export class MpManagerComponent implements OnInit {

  currentPage = 1;
  pages: number[] = [];
  paginator: MPPaginatorModel | undefined;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.GoToPage();
  }

  ngOnInit(): void {
  }

  GoToPage() {
    this.http.get<MPPaginatorModel>(this.baseUrl + `api/mp?page=${this.currentPage}`)
      .subscribe(v => {
        this.paginator = v;
        this.pages = Array(v.pageCount).fill(1).map((x, i) => i + 1);
      });
  }

  ChangePage(page: number) {
    this.currentPage = page;
    this.GoToPage();
  }

  IncreasePage() {
    if (!this.paginator) return;
    this.currentPage + 1 > this.paginator.pageCount ? this.paginator.pageCount : this.currentPage++;
    this.GoToPage();
  }

  DecreasePage() {
    if (!this.paginator) return;
    this.currentPage - 1 < 1 ? 1 : this.currentPage--;
    this.GoToPage();
  }

}
