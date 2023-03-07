
export enum PATHS {
    MOVIES = 'movies',
}

export enum SEGMENTS {
    NEW = 'new',
}

const idParam = ':id'

export const MOVIE_LIST_URL = PATHS.MOVIES;

export const MOVIE_FORM_URL = `${PATHS.MOVIES}/${idParam}`;

export const getMovieFormUrl = (id: string | number): string => {
    let url = MOVIE_FORM_URL;
    return url.replace(idParam, id?.toString());
};

export const ADD_MOVIE_URL = getMovieFormUrl(SEGMENTS.NEW);
