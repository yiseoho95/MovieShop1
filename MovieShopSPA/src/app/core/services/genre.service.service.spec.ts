import { TestBed } from '@angular/core/testing';

import { Genre.ServiceService } from './genre.service.service';

describe('Genre.ServiceService', () => {
  let service: Genre.ServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Genre.ServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
