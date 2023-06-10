import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MpManagerComponent } from './mp-manager.component';

describe('MpManagerComponent', () => {
  let component: MpManagerComponent;
  let fixture: ComponentFixture<MpManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MpManagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MpManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
