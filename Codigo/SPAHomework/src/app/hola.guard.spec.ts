import { TestBed } from '@angular/core/testing';

import { HolaGuard } from './guards/hola.guard';

describe('HolaGuard', () => {
  let guard: HolaGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(HolaGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
