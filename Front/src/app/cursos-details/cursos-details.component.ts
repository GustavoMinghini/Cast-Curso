import { CursoDetailService } from './../shared/curso-detail.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CursoDetail } from '../shared/curso-detail.model';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-cursos-details',
  templateUrl: './cursos-details.component.html',
  styleUrls: ['./cursos-details.component.css']
})
export class CursosDetailsComponent implements OnInit {

  filteredString: string = '';

  currentDate = new Date();


  datainitial = new Date();
  router: any;
  constructor(public service: CursoDetailService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.service.refreshList();
      this.service.refreshList2();
      this.service.refreshList3();


    }


  populateForm(selectedRecord: CursoDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
    this.router.navigate(['/curso'])
  }


  dataAtual(DtInicio: any){
    console.log(DtInicio)
    this.datainitial = DtInicio.value
  }
  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteCursoDetail(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Deletado com Sucesso", 'Curso Deletado');
          },
          err => { console.log(err)
            var text = JSON.stringify(err.error);
            this.toastr.error('Submit Failed', text) }
        )
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.cursoId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postCursoDetail().subscribe(
      (response:any) => {
        this.toastr.success('Enviado com Sucesso', 'Curso Criado')
        this.service.formLog.cursoId = response.id;
        this.service.formLog.dtInclusao = this.currentDate;
        this.service.formLog.tabelaLogId = 0;
        this.insertLog()
        this.service.refreshList();
        this.resetForm(form);
      },
      err => { console.log(err);
              var text = JSON.stringify(err.error);
               this.toastr.error('Submit Failed', text)
               console.log(err);
      }
    );
  }

  insertLog() {
    this.service.postLog().subscribe(
      (response:any) => {
        console.log(response)
        this.toastr.success('Log Criado Com Sucesso')
      },
      err => { console.log(err);
              var text = JSON.stringify(err.error);
               this.toastr.error('Submit Failed', text)
      }
    );
  }


  updateRecord(form: NgForm) {
    this.service.putCursoDetail().subscribe(
      res => {
        this.toastr.success('Enviado com Sucesso', 'Atualizado Com Sucesso')
        this.service.formLog.cursoId = this.service.formData.cursoId;
        this.service.formLog.dtUltimaAtt = this.currentDate;
        this.service.formLog.tabelaLogId = 0;
        const usuario = document.getElementsByName("usuarioResponsavel");
        console.log( usuario.item.toString());
        this.service.formLog.usuarioResponsavel = this.service.formLog.usuarioResponsavel;
        this.insertLog()
        this.service.refreshList();
        this.resetForm(form);
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new CursoDetail();
  }


}



