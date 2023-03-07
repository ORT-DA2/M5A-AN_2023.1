import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { IHomework } from '../models/IHomework';
import { HomeworksService } from '../services/homeworks.service';

@Component({
  selector: 'app-homeworks-list',
  templateUrl: './homeworks-list.component.html',
  styleUrls: ['./homeworks-list.component.scss']
})

export class HomeworksListComponent implements OnChanges {
    pageTitle:string = "Homeworks List";
    listFilter:string = "";
    showExercises:boolean = false;
    homeworks$: Observable<IHomework[]>;

    constructor(private _homeworks: HomeworksService) { 
        this.homeworks$ = _homeworks.getHomeworks();
    }

    ngOnChanges(changes: SimpleChanges): void {
        console.log("aaa");
    }

    public toggleExercises(): void {
        this.showExercises = !this.showExercises;
    }

    public onRatingClicked(message:string): void {
        this.pageTitle = 'Homeworks List: ' + message;
    }

}