import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Mainpage2Component } from './mainpage2.component';

describe('Mainpage2Component', () => {
  let component: Mainpage2Component;
  let fixture: ComponentFixture<Mainpage2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Mainpage2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Mainpage2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
