import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailBeerComponent } from './detail-beer.component';

describe('DetailBeerComponent', () => {
  let component: DetailBeerComponent;
  let fixture: ComponentFixture<DetailBeerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailBeerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailBeerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
