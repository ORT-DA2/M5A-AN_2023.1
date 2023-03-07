import { TestBed } from '@angular/core/testing';

import { ProductServicesService } from './product-services.service';

describe('ProductServicesService', () => {
  let service: ProductServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
