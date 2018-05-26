import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatoSinglepageComponent } from './candidato-singlepage.component';

describe('CandidatoSinglepageComponent', () => {
  let component: CandidatoSinglepageComponent;
  let fixture: ComponentFixture<CandidatoSinglepageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CandidatoSinglepageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidatoSinglepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
