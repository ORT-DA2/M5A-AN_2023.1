import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPubComponent } from './new-pub.component';

describe('NewPubComponent', () => {
  let component: NewPubComponent;
  let fixture: ComponentFixture<NewPubComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewPubComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewPubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
