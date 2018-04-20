import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { CandidatosComponent } from './candidatos/candidatos.component';

const appRoutes: Routes = [
        { path:'main', component:MainComponent },
        { path:'candidatos',component:CandidatosComponent}
        // { path:'**', component:FrutasComponent }
    ];


export const appRoutingProviders: any = [];
export const routing: ModuleWithProviders = RouterModule.forRoot (appRoutes);