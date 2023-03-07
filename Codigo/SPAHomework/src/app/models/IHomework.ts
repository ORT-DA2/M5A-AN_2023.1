import { IExercise } from './IExercise';

export interface IHomework {
    id: string;
    description: string;
    dueDate: Date;
    score: number;
    exercises: Array<IExercise>;
    rating: number;
}