import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyPubComponent } from './modify-pub.component';

describe('ModifyPubComponent', () => {
  let component: ModifyPubComponent;
  let fixture: ComponentFixture<ModifyPubComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifyPubComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyPubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
