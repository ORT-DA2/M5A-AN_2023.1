import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPubsComponent } from './list-pubs/list-pubs.component';
import { NewPubComponent } from './new-pub/new-pub.component';
import { FormsModule } from '@angular/forms';
import { ModifyPubComponent } from './modify-pub/modify-pub.component';



@NgModule({
  declarations: [ListPubsComponent, NewPubComponent, ModifyPubComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ListPubsComponent, NewPubComponent, ModifyPubComponent]
})
export class PubsModule { }
