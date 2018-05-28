import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PeticionService {
  public url: string;
  public state:boolean;

  constructor(private _http:Http) {
    this.url="http://amoralesg.azurewebsites.net/api/candidate";
   }

  getInfo() {
    this.state = true;
    return this._http.get(this.url)
    .map(res => res.json());
  }

}
