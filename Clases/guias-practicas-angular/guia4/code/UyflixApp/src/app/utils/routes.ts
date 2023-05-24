
export enum PATHS {
    MOVIES = 'movies',
    ADMIN = 'admin',
}

export enum SEGMENTS {
    NEW = 'new',
}

export const ROUTE_ID_PARAM = 'id';

export const ROUTE_CONFIG_ID_PARAM = ':id';

export const MOVIE_LIST_URL = PATHS.MOVIES;

export const MOVIE_FORM_URL = `${PATHS.MOVIES}/${ROUTE_CONFIG_ID_PARAM}`;

export const getUrl = (url: string, paramKey: string, paramValue: string | number): string =>
    url.replace(paramKey, paramValue?.toString());

export const ADD_MOVIE_URL = getUrl(MOVIE_FORM_URL, ROUTE_CONFIG_ID_PARAM, SEGMENTS.NEW);

export const ADMIN_URL = PATHS.ADMIN;
