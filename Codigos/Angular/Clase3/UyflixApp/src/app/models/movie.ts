export class Movie {
    id: number;
    name: string;
    category: string;
    director: string;
    country: string;
    year: number;
    rating: number;

    constructor(id: number, name: string, category: string, director: string, country: string,
        year: number, rating: number) {
        this.id = id;
        this.name = name;
        this.category = category;
        this.director = director;
        this.country = country;
        this.year = year;
        this.rating = rating;
    }
}