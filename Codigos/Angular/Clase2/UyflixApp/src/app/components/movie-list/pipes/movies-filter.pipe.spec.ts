import { MoviesFilterPipe } from './movies-filter.pipe';

describe('MoviesFilterPipe', () => {
  it('create an instance', () => {
    const pipe = new MoviesFilterPipe();
    expect(pipe).toBeTruthy();
  });
});
