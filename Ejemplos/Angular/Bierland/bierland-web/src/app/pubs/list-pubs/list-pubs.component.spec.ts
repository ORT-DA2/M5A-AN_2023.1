import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPubsComponent } from './list-pubs.component';

describe('ListPubsComponent', () => {
  let component: ListPubsComponent;
  let fixture: ComponentFixture<ListPubsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPubsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPubsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
