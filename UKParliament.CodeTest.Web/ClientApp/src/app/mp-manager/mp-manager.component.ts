import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-mp-manager',
  templateUrl: './mp-manager.component.html',
  styleUrls: ['./mp-manager.component.scss']
})
export class MpManagerComponent implements OnInit {

  mps: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.GetAllMPs();
  }

  ngOnInit(): void {
  }

  GetAllMPs() {
    this.mps = this.http.get(this.baseUrl + `api/person`, { params: { "expanded": true } });
    this.http.get(this.baseUrl + `api/person`).subscribe(r => console.log(r));
  }

}
