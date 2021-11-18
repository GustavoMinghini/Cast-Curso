import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CursoDetail } from '../shared/curso-detail.model';
import { CursoDetailService } from '../shared/curso-detail.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-cursos-list',
  templateUrl: './cursos-list.component.html',
  styleUrls: ['./cursos-list.component.css']
})
export class CursosListComponent implements OnInit {

  filteredString: string = '';

  constructor(public service: CursoDetailService,
    private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: CursoDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
    this.router.navigateByUrl('curso');
  }

  onDelete(id: number) {
    if (confirm('Voce tem certeza que quer deletar?')) {
      this.service.deleteCursoDetail(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Deletado Com Sucesso", 'Curso Deletado');
          },
          err => { console.log(err)
            var text = JSON.stringify(err.error);
            this.toastr.error('Submit Failed', text) }
        )
    }
  }

}
