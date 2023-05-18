
export enum PATHS {
    MOVIES = 'movies',
}

export enum SEGMENTS {
    NEW = 'new',
}

export const idParam = ':id'

export const MOVIE_LIST_URL = PATHS.MOVIES;

export const MOVIE_FORM_URL = `${PATHS.MOVIES}/${idParam}`;

export const getUrl = (url: string, paramKey: string, paramValue: string | number): string =>
    url.replace(paramKey, paramValue?.toString());

export const ADD_MOVIE_URL = getUrl(MOVIE_FORM_URL, idParam, SEGMENTS.NEW);
