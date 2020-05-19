import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScanitemComponent } from './scanitem.component';

describe('ScanitemComponent', () => {
  let component: ScanitemComponent;
  let fixture: ComponentFixture<ScanitemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScanitemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScanitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
