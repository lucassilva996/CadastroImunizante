import { Component, OnInit } from '@angular/core';
import { ImunizanteService } from './services/imunizante.service';
import { Imunizante } from './models/imunizante';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {

  imunizante = {} as Imunizante;
  imunizantes!: Imunizante[];

  constructor(private imunizanteService : ImunizanteService) {}

  ngOnInit() {
      this.getImunizante();
  }

  saveImunizante(form : NgForm) {
    if(this.imunizante.Id !== undefined) {
      this.imunizanteService.updateImunizante(this.imunizante).subscribe(()=>{
        this.cleanForm(form);
      });
    } else {
      this.imunizanteService.saveImunizante(this.imunizante).subscribe(()=>{
        this.cleanForm(form);
      });
    }
  }

  getImunizante() {
    this.imunizanteService.getImunizante().subscribe((imunizantes : Imunizante[])=>{
      this.imunizantes = imunizantes;
    });
  }

  deleteImunizante(imunizante : Imunizante) {
    this.imunizanteService.deleteImunizante(imunizante).subscribe(()=>{
      this.getImunizante();
    })
  }

  editImunizante(imunizante : Imunizante) {
    this.imunizante = {...imunizante};
  }

  cleanForm(form: NgForm) {
    this.getImunizante();
    form.resetForm();
    this.imunizante = {} as Imunizante;
  }

 
}
