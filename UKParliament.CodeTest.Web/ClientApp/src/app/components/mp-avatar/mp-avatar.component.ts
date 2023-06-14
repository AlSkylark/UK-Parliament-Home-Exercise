import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-mp-avatar',
  templateUrl: './mp-avatar.component.html',
  styleUrls: ['./mp-avatar.component.scss']
})
export class MpAvatarComponent implements OnInit {

  @Input() colour!: string;
  constructor() { }

  ngOnInit(): void {
  }

}
