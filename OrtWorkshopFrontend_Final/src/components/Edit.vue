<template>
  <div>
      <h2>Edit Movie</h2>
      <div class="form">
        <label for="title">Title</label>
        <input type="text" id="title" v-model="movie.title"/>
      </div>
      <div class="form">
        <label for="genre">Genre</label>
        <input type="text" id="genre" v-model="movie.genre"/>
      </div>
      <div class="form">
        <label for="year">Year</label>
        <input type="number" id="year" v-model="movie.year"/>
      </div>
      <div class="form">
        <label for="director">Director</label>
        <input type="text" id="director" v-model="movie.director"/>
      </div>
      <button type="button" v-on:click="cancel()">Cancel</button>
      <button type="button" v-on:click="save()">Save</button>
  </div>
</template>

<script>
import Services from '@/services'

export default {
  name: 'Edit',
  data: () => {
    return {
      movie: {}
    }
  },
  created: function () {
    this.load()
  },
  methods: {
    load: function () {
      Services.getMovie(this.$route.params.id)
      .then(response => response.json())
      .then((jsonResponse) => {
        this.movie = jsonResponse
      })
    },
    save: function () {
      Services.updateMovie(this.movie)
      .then(() => this.$router.push('/list'))
    },
    cancel: function () {
      this.$router.push('/list')
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
