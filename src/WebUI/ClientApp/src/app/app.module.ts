import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { GlossaryComponent } from './components/glossary/glossary.component';
import {TableModule} from 'ngx-easy-table';
import { TermAddComponent } from './components/term-add/term-add.component';
import {Router, RouterModule, Routes} from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';
import { TermEditComponent } from './components/term-edit/term-edit.component';
import {HttpClientModule} from '@angular/common/http';

const routes: Routes = [
  { path: '', component: GlossaryComponent},
  { path: 'add-term', component: TermAddComponent},
  { path: 'edit-term/:id', component: TermEditComponent},
  { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    GlossaryComponent,
    TermAddComponent,
    TermEditComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    TableModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
