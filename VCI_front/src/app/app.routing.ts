import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { HeaderComponent } from './header/header.component';

const appRoutes: Routes = [
        { path:'main', component:MainComponent }
        // { path:'**', component:FrutasComponent }
    ];


export const appRoutingProviders: any = [];
export const routing: ModuleWithProviders = RouterModule.forRoot (appRoutes);