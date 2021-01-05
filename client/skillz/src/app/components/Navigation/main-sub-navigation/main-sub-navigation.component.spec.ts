import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainSubNavigationComponent } from './main-sub-navigation.component';

describe('MainSubNavigationComponent', () => {
  let component: MainSubNavigationComponent;
  let fixture: ComponentFixture<MainSubNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainSubNavigationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MainSubNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
