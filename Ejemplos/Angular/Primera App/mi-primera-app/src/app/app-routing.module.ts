import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductNotExistGuard } from './components/product-detail/guards/product-not-exist.guard';
import { ProductAddComponent } from './components/product-add/product-add.component';

const routes: Routes = [
  { path: '', component: ProductListComponent },
  { path: 'product/add', component: ProductAddComponent },
  {
    path: 'product/:id',
    component: ProductDetailComponent,
    canActivate: [ProductNotExistGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
