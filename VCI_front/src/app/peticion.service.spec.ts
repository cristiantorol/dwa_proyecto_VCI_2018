import { TestBed, inject } from '@angular/core/testing';

import { PeticionService } from './peticion.service';

describe('PeticionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PeticionService]
    });
  });

  it('should be created', inject([PeticionService], (service: PeticionService) => {
    expect(service).toBeTruthy();
  }));
});
