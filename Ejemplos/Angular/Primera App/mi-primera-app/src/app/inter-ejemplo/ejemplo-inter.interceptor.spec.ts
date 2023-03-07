import { TestBed } from '@angular/core/testing';

import { EjemploInterInterceptor } from './ejemplo-inter.interceptor';

describe('EjemploInterInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      EjemploInterInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: EjemploInterInterceptor = TestBed.inject(EjemploInterInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
