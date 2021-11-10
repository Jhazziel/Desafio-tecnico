import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: 'list', loadChildren: () => import('./pages/meels/list/list.module').then(m => m.ListModule) }, { path: 'new', loadChildren: () => import('./pages/meels/new/new.module').then(m => m.NewModule) }, { path: 'details', loadChildren: () => import('./pages/meels/details/details.module').then(m => m.DetailsModule) }, { path: 'menu', loadChildren: () => import('./pages/meels/menu/menu.module').then(m => m.MenuModule) }, { path: 'edit', loadChildren: () => import('./pages/meels/edit/edit.module').then(m => m.EditModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
