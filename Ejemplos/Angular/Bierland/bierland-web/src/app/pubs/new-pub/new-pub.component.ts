import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Pub } from 'src/Models/Pub';
import { PubsService } from '../services/pubs.service';

@Component({
  selector: 'app-new-pub',
  templateUrl: './new-pub.component.html',
  styleUrls: ['./new-pub.component.css'],
})
export class NewPubComponent {
  name: string;
  address: string;
  constructor(private pubService: PubsService, private router: Router) {
    this.name = '';
    this.address = '';
  }

  createPub(): void {
    const newPub = new Pub(this.name, this.address);
    this.pubService.addPub(newPub).subscribe(
      (res) => {
        this.router.navigate(['/pubs']);
      },
      (err) => {
        alert('Ups, algo salió mal...');
        console.log(err);
      }
    );
  }
}
