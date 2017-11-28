const url = 'http://localhost:5000/api/movie'

export default {
  getMovies: function () {
    return fetch(url)
  },
  saveMovie: function (movie) {

  }
}
