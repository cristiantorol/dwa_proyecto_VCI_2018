import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { CandidatoSinglepageComponent } from './candidato-singlepage/candidato-singlepage.component';
import { AdministradorComponent } from './administrador/administrador.component';
import {CandidatosRegistradosComponent} from './candidatos-registrados/candidatos-registrados.component';
import {RegistroComponent} from './registro/registro.component';

const appRoutes: Routes = [
        { path:'', component:MainComponent },
        { path:'main', component:MainComponent },
        { path:'candidatos',component:CandidatosComponent},
        { path:'candidato',component:CandidatoSinglepageComponent},
        { path:'candidato/:ident', component:CandidatoSinglepageComponent },
        { path:'administrador', component:AdministradorComponent},
        { path:'registrados', component:CandidatosRegistradosComponent},
        { path:'registrar', component:RegistroComponent}
        // { path:'**', component:FrutasComponent }
    ];


export const appRoutingProviders: any = [];
export const routing: ModuleWithProviders = RouterModule.forRoot (appRoutes);