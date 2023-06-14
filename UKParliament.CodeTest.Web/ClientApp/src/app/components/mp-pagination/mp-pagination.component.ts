import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MPPaginatorModel } from 'src/models/mp-paginator-model';

@Component({
  selector: 'app-mp-pagination',
  templateUrl: './mp-pagination.component.html',
  styleUrls: ['./mp-pagination.component.scss']
})
export class MpPaginationComponent implements OnInit {

  @Input() paginator!: MPPaginatorModel;

  pages: number[] = [];
  currentPage = 1;

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
