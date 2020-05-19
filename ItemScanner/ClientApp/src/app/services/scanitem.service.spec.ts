import { TestBed } from '@angular/core/testing';

import { ScanitemService } from './scanitem.service';

describe('ScanitemService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ScanitemService = TestBed.get(ScanitemService);
    expect(service).toBeTruthy();
  });
});
