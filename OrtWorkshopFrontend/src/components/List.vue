<template>
  <div>
    <h1>{{ msg }}</h1>
    <table>
      <tr>
        <th>Title</th>
        <th>Genre</th>
      </tr>
      <tr v-for="movie in movies">
        <td>{{ movie.title }}</td>
        <td>{{ movie.genre }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
import Services from '@/services'

export default {
  name: 'List',
  data () {
    return {
      msg: 'List',
      movies: Services.getMovies()
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
