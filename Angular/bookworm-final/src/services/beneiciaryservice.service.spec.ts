import { TestBed } from '@angular/core/testing';

import { BeneiciaryserviceService } from './beneiciaryservice.service';

describe('BeneiciaryserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BeneiciaryserviceService = TestBed.get(BeneiciaryserviceService);
    expect(service).toBeTruthy();
  });
});
