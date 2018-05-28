import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { routing, appRoutingProviders } from './app.routing';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { HttpModule, Http } from '@angular/http';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MainComponent } from './main/main.component';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { CandidatoSinglepageComponent } from './candidato-singlepage/candidato-singlepage.component';
import { AdministradorComponent } from './administrador/administrador.component';
import { RegistroComponent } from './registro/registro.component';
import { CandidatosRegistradosComponent } from './candidatos-registrados/candidatos-registrados.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    CandidatosComponent,
    CandidatoSinglepageComponent,
    AdministradorComponent,
    RegistroComponent,
    CandidatosRegistradosComponent
  ],
  imports: [
    BrowserModule,
    routing,
    BrowserAnimationsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
