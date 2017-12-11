const url = 'http://localhost:5000/api/movie'

export default {
  getMovies: () => {
    return fetch(url)
  },
  getMovie: (id) => {
    return fetch(`${url}/${id}`)
  },
  saveMovie: (movie) => {
    return fetch(url, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method: 'POST',
      body: JSON.stringify(movie)
    })
  },
  updateMovie: (movie) => {
    return fetch(`${url}/${movie.movieId}`, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method: 'PUT',
      body: JSON.stringify(movie)
    })
  },
  removeMovie: (movie) => {
    return fetch(`${url}/${movie.movieId}`, {method: 'DELETE'})
  }
}
