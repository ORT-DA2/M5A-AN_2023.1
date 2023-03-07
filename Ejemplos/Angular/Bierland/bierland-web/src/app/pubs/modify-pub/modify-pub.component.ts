import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pub } from 'src/Models/Pub';
import { PubsService } from '../services/pubs.service';

@Component({
  selector: 'app-modify-pub',
  templateUrl: './modify-pub.component.html',
  styleUrls: ['./modify-pub.component.css'],
})
export class ModifyPubComponent implements OnInit {
  name: string;
  address: string;
  constructor(
    private pubService: PubsService,
    private router: Router,
    private currentRoute: ActivatedRoute
  ) {
    this.name = '';
    this.address = '';
  }

  ngOnInit(): void {
    this.pubService.getPubById(this.currentRoute.snapshot.params.id).subscribe(
      (res) => {
        this.name = res.name;
        this.address = res.address;
      },
      (err) => {
        alert(err);
      }
    );
  }

  modifyPub(): void {
    const pub = new Pub(this.name, this.address);
    pub.id = this.currentRoute.snapshot.params.id;
    this.pubService.putPub(pub).subscribe(
      res => {
        this.router.navigate(['/pubs']);
      },
      err => {
        alert('Ups, algo salió mal...');
        console.log(err);
      }
    );
  }

  deletePub(): void {
    this.pubService.deletePub(this.currentRoute.snapshot.params.id).subscribe(
      res => {
        this.router.navigate(['/pubs']);
      },
      err => {
        alert('Ups, algo salió mal...');
        console.log(err);
      }
    );
  }
}
