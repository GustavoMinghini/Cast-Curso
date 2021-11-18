import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CursosDetailsComponent } from './cursos-details/cursos-details.component';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { FilterPipe } from './shared/filter.pipe';
import { Ng2SearchPipeModule } from "ng2-search-filter";
import { IndexComponent } from './index/index.component';
import { AppRoutingModule } from './app-routing.module';
import { CursosListComponent } from './cursos-list/cursos-list.component';





@NgModule({
  declarations: [
    AppComponent,
    CursosDetailsComponent,
    FilterPipe,
    IndexComponent,
    CursosListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    Ng2SearchPipeModule,
    ToastrModule.forRoot(),
    AppRoutingModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
