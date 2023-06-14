import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MpEditorComponent } from './mp-editor.component';

describe('MpEditorComponent', () => {
  let component: MpEditorComponent;
  let fixture: ComponentFixture<MpEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MpEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MpEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
