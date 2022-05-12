import { Component, OnInit } from '@angular/core';
import { ImunizanteService } from 'src/app/shared/imunizante.service'; 
import { NgForm } from '@angular/forms';
import { Imunizante } from 'src/app/shared/imunizante'; 
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-imunizante-detail-form',
  templateUrl: './imunizante-detail-form.component.html',
  styles: [
  ]
})
export class ImunizanteDetailFormComponent implements OnInit {

  constructor(public service: ImunizanteService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.Id == 0) 
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.saveImunizante().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Registro inserido com sucesso!')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.updateImunizante().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Registro atualizado com sucesso!')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Imunizante();
  }

}