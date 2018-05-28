import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatosRegistradosComponent } from './candidatos-registrados.component';

describe('CandidatosRegistradosComponent', () => {
  let component: CandidatosRegistradosComponent;
  let fixture: ComponentFixture<CandidatosRegistradosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CandidatosRegistradosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidatosRegistradosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
