import { CursosListComponent } from './cursos-list/cursos-list.component';
import { CursosDetailsComponent } from './cursos-details/cursos-details.component';
import { IndexComponent } from './index/index.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';



const routes: Routes = [
  {path:'', component: IndexComponent},
  {path: 'curso', component: CursosDetailsComponent},
  {path: 'cursolist', component: CursosListComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
