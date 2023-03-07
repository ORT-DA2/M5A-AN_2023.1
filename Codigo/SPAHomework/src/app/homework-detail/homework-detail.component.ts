import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Homework } from '../models/Homework';
import { IHomework } from '../models/IHomework';
import { HomeworksService } from '../services/homeworks.service';

@Component({
  selector: 'app-homework-detail',
  templateUrl: './homework-detail.component.html',
  styleUrls: ['./homework-detail.component.scss']
})
export class HomeworkDetailComponent implements OnInit {

  pageTitle: string = 'Homework Detail';
  homework$: Observable<IHomework>;

  constructor(private _currentRoute: ActivatedRoute, private _router : Router, private _homeworks: HomeworksService) {  
    this.homework$ = of(new Homework());
  }

  ngOnInit() : void {
    // let (es parte de ES2015) y define una variable que vive en este scope
    // usamos el nombre del parámetro que usamos en la configuración de la ruta y lo obtenemos
    let id = this._currentRoute.snapshot.params['id'];
    // definimos el string con interpolation 
    this.pageTitle += `: ${id}`;
    this.homework$ = this._homeworks.get(id);
  }

  onBack(): void {
    this._router.navigate(['/homeworks']);
  }

}
