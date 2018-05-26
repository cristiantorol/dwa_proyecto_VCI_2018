import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate, state} from '@angular/animations';

@Component({
  selector: 'app-candidatos',
  templateUrl: './candidatos.component.html',
  styleUrls: ['./candidatos.component.scss'],
  animations: [ 
    trigger('mouseStatus',[
      state('over',style({
        transform: 'scale(1.05)'
      })),
      state('notOver',style({
        transform: 'scale(1)'
      })),
      transition('over => notOver',animate('500ms ease-in')),
      transition('notOver => over',animate('500ms ease-out')),
    ])
   ]
})
export class CandidatosComponent implements OnInit {
  mouseStatus: String = 'notOver';
  constructor() { }

  over(_state:boolean){
    this.mouseStatus = _state ? 'over' : 'notOver';
  }

  ngOnInit() {
  }

}
