import { TestBed } from '@angular/core/testing';

import { PubsService } from './pubs.service';

describe('PubsService', () => {
  let service: PubsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PubsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
