import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FixesComponent } from './fixes.component';

describe('EventsComponent', () => {
  let component: FixesComponent;
  let fixture: ComponentFixture<FixesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FixesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FixesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
