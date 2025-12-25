import { Component } from '@angular/core';
import {  FttRequest } from '../Class';

@Component({
  selector: 'app-ftt-request',
  templateUrl: './ftt-request.component.html',
  styleUrls: ['./ftt-request.component.scss']
})
export class FttRequestComponent {

  fttRequest:FttRequest;

  constructor() {
    this.fttRequest = new  FttRequest();
   
  }
  
   OnSubmit() {
   console.log("value",this.fttRequest);
   }
  }