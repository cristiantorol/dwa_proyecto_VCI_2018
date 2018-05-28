import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { CandidatoSinglepageComponent } from './candidato-singlepage/candidato-singlepage.component';

const appRoutes: Routes = [
        { path:'', component:MainComponent },
        { path:'main', component:MainComponent },
        { path:'candidatos',component:CandidatosComponent},
        { path:'candidato',component:CandidatoSinglepageComponent},
        { path:'candidato/:ident', component:CandidatoSinglepageComponent },
        // { path:'**', component:FrutasComponent }
    ];


export const appRoutingProviders: any = [];
export const routing: ModuleWithProviders = RouterModule.forRoot (appRoutes);