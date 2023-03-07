import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pub } from '../../../Models/Pub';
import { PubsService } from '../services/pubs.service';

@Component({
  selector: 'app-list-pubs',
  templateUrl: './list-pubs.component.html',
  styleUrls: ['./list-pubs.component.css'],
})
export class ListPubsComponent implements OnInit {
  pubs;

  constructor(private pubservice: PubsService, private router: Router) {
    this.pubs = [];
  }

  ngOnInit(): void {
    this.pubservice.getPubs().subscribe(
      (res) => {
        this.pubs = res;
      },
      (err) => {
        alert('Ups, algo salió mal...');
        console.log(err);
      }
    );
  }

  addPub(): void {
    this.router.navigate(['/new-pub']);
  }

  selectPub(id: number): void {
    console.log(id);
    this.router.navigate(['/modify-pub', id]);
  }
}
