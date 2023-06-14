import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {

  today = formatDate(Date.now(), 'dd MMMM yyyy', 'en_GB');
  constructor() { }

  ngOnInit(): void {
  }

}
