import { TestBed } from '@angular/core/testing';

import { BeerNotExistGuard } from './beer-not-exist.guard';

describe('BeerNotExistGuard', () => {
  let guard: BeerNotExistGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(BeerNotExistGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
