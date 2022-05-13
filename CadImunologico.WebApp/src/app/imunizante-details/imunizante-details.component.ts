import { Component, OnInit } from '@angular/core';
import { ImunizanteService } from '../shared/imunizante.service';
import { Imunizante } from '../shared/imunizante';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-imunizante-details',
  templateUrl: './imunizante-details.component.html',
  styles: [
  ]
})

export class ImunizanteDetailsComponent implements OnInit {

  constructor(public service : ImunizanteService, 
    private toastr: ToastrService ) {}
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Imunizante) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(Id: number) {
    if(confirm('Você deseja deletar este registro?')) {
      this.service.deleteImunizante(Id)
      .subscribe(
        res => {
          this.service.refreshList();
          this.toastr.error("Registro excluído");
        }, 
        err => { console.log(err)}
      )
    }
  }
 
}
