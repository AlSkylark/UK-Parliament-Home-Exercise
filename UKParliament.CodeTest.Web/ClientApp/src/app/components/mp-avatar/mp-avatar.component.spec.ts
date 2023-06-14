import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MpAvatarComponent } from './mp-avatar.component';

describe('MpAvatarComponent', () => {
  let component: MpAvatarComponent;
  let fixture: ComponentFixture<MpAvatarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MpAvatarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MpAvatarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
