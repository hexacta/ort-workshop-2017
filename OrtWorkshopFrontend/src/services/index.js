const url = 'http://localhost:5000/api/movie'

export default {
  getMovies: () => {
    return fetch(url)
  },
  saveMovie: (movie) => {

  },
  removeMovie: (movie) => {
    return fetch(`${url}/${movie.movieId}`, {method: 'DELETE'})
  }
}
