import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { IHomework } from '../models/IHomework';
import { HomeworksService } from '../services/homeworks.service';

@Component({
  selector: 'app-homework-create',
  templateUrl: './homework-create.component.html',
  styleUrls: ['./homework-create.component.scss']
})
export class HomeworkCreateComponent {
  homeworkForm = this._fb.group({
    description: ['', Validators.required],
    rating: [0, Validators.compose([Validators.min(1), Validators.max(5)])],
    score: [0, Validators.min(1)],
    dueDate: [null, Validators.required],
    exercises: this._fb.array([])
  });

  constructor(private _fb: FormBuilder, private _service: HomeworksService) { }

  onSubmit() {
    const h : IHomework = this.homeworkForm.value;
    this._service.create(h)
      .pipe(first())
      .subscribe(x => console.log(x));
  }

}
