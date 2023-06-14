import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MpPaginationComponent } from './mp-pagination.component';

describe('MpPaginationComponent', () => {
  let component: MpPaginationComponent;
  let fixture: ComponentFixture<MpPaginationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MpPaginationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MpPaginationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
