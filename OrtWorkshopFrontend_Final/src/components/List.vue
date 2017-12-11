<template>
  <div>
    <h1>Movies</h1>
    <table>
      <tr>
        <th>Title</th>
        <th>Genre</th>
        <th></th>
      </tr>
      <tr v-for="movie in movies" :key="movie.movieId">
        <td><a :href="'#/edit/' + movie.movieId">{{ movie.title }}</a></td>
        <td>{{ movie.genre }}</td>
        <td><a v-on:click="remove(movie)">Delete</a></td>
      </tr>
    </table>
  </div>
</template>

<script>
import Services from '@/services'

export default {
  name: 'List',
  data: () => {
    return {
      movies: []
    }
  },
  created: function () {
    this.load()
  },
  methods: {
    load: function () {
      Services.getMovies()
      .then(response => response.json())
      .then((jsonResponse) => {
        this.movies = jsonResponse
      })
    },
    remove: function (movie) {
      Services.removeMovie(movie)
      .then(() => this.load())
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
table {
  width: 500px;
  margin: auto;
}
</style>
