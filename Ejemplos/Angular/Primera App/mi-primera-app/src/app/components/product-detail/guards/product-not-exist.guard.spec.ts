import { TestBed } from '@angular/core/testing';

import { ProductNotExistGuard } from './product-not-exist.guard';

describe('ProductNotExistGuard', () => {
  let guard: ProductNotExistGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ProductNotExistGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
