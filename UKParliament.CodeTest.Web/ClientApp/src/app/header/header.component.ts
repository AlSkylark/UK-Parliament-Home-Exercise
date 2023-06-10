import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }


  title: string | undefined;

  //simulate breadcrumbs
  breadcrumbs: boolean = false;

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      //when finished navigating get the title
      if (event instanceof NavigationEnd) {
        this.title = this.activatedRoute.firstChild?.snapshot
          .routeConfig?.title?.toString();
        this.breadcrumbs = (this.title === "MP Manager");
      }
    });
  }

}
