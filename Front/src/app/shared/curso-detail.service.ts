import { Categoria } from './categoria.model';
import { CursoDetail } from './curso-detail.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Usuarios } from './usuarios.model';
import { TabelaLog } from './tabelalog.model';

@Injectable({
  providedIn: 'root'
})
export class CursoDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44331/api/Cursos'
  readonly CategoriaURL = 'https://localhost:44331/api/Categorias'
  readonly UsuarioURL = 'https://localhost:44331/api/Usuarios'
  readonly logURL = 'https://localhost:44331/api/TabelaLogs'
  formData: CursoDetail = new CursoDetail();
  formLog: TabelaLog = new TabelaLog();
  list: CursoDetail[];
  list2: Categoria[];
  list3: Usuarios[];

  postCursoDetail() {
    console.log(this.formData)
    return this.http.post(this.baseURL, this.formData);
  }
  postLog() {
    return this.http.post(this.logURL, this.formLog);
  }

  putCursoDetail() {
    let a = this.formData;


    return this.http.put(`${this.baseURL}/${this.formData.cursoId}`, a);
  }

  deleteCursoDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res =>this.list = res as CursoDetail[]);
  }
  refreshList2() {
    this.http.get(this.CategoriaURL)
      .toPromise()
      .then(res =>this.list2 = res as Categoria[]);
  }
  refreshList3() {
    this.http.get(this.UsuarioURL)
      .toPromise()
      .then(res =>this.list3 = res as Usuarios[]);
  }

}
