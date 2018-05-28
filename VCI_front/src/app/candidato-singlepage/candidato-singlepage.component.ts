import { Component, OnInit } from '@angular/core';
import { Candidato, Propuesta } from '../candidato-singlepage/candidato';
import { PeticionService } from '../peticion.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-candidato-singlepage',
  templateUrl: './candidato-singlepage.component.html',
  styleUrls: ['./candidato-singlepage.component.scss','./animate.css'],
  providers:[PeticionService]
})
export class CandidatoSinglepageComponent implements OnInit {
  public _propuestas:Array<Propuesta> = [];
  public parametro:String;
  public data: any[];

  constructor(
    private _route: ActivatedRoute,
    private _peticionService: PeticionService
  ) { }

  ngOnInit() {
    this._route.params.forEach((params:Params) => {
      this.parametro = params['ident'];
      console.log(this.parametro)
    });

    this.data = JSON.parse(localStorage.getItem("candidatos"));  
    console.log(this.data); 
    for(var j=0;j<4;j++){
      this._propuestas.push(new Propuesta(this.data.Result[Number(this.parametro)].Proposals[j].Title,this.data.Result[Number(this.parametro)].Proposals[j].Description));
    }
    console.log(this._propuestas);

  }

}
