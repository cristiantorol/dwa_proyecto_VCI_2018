import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate, state} from '@angular/animations';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Candidato, Propuesta } from '../candidato-singlepage/candidato';
import { PeticionService } from '../peticion.service';


@Component({
  selector: 'app-candidatos',
  templateUrl: './candidatos.component.html',
  styleUrls: ['./candidatos.component.scss'],
  providers:[PeticionService],
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
  public _candidatos:Array<Candidato> = [];
  constructor(
    private _router: Router,
    private _peticionService: PeticionService
  ) { }

  routing(_index){
    this._router.navigate(['/candidato/'+_index]);
  }

  over(_state:boolean){
    this.mouseStatus = _state ? 'over' : 'notOver';
  }

  ngOnInit() {
    this._peticionService.getInfo().subscribe(
      result =>{
        console.log(result);
        var data = JSON.stringify(result);
        localStorage.setItem("candidatos",data);
        for(var item in result.Result){
          var date = result.Result[item].BirthDate.split("T",1);
          var img = result.Result[item].ProfileFoto;
          var propuestas=[];
          for(var i=0;i<4;i++){
            propuestas.push(new Propuesta(result.Result[item].Proposals[i].Title,result.Result[item].Proposals[i].Description));
          }
          this._candidatos.push(new Candidato(result.Result[item].Names,result.Result[item].LastNames,
            img,date,result.Result[item].Identification,result.Result[item].PoliticParty,
            result.Result[item].Biography,propuestas));
        }
        console.log(this._candidatos);
      },
      error => {
        var errorMsj = <any>error;
        console.log(errorMsj);
      }
    )
  }

}
