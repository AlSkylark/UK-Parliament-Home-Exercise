import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MpItemComponent } from './mp-item.component';

describe('MpItemComponent', () => {
  let component: MpItemComponent;
  let fixture: ComponentFixture<MpItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MpItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MpItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
