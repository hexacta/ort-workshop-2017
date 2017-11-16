<template>
  <div>
    <h1>{{ msg }}</h1>
    <div>
      <label for="title">Title</label>
      <input type="text" id="title" v-model="title"/>
    </div>
    <div>
      <label for="genre">Genre</label>
      <select id="genre" v-model="genre">
        <option value="action">Action</option>
        <option value="comedy">Comedy</option>
        <option value="horror">Horror</option>
      </select>
    </div>
    <button type="button" v-on:click="save()">Save</button>
  </div>
</template>

<script>
import Services from '@/services'

export default {
  name: 'New',
  data () {
    return {
      msg: 'New movie',
      title: '',
      genre: ''
    }
  },
  methods: {
    save: function () {
      Services.saveMovie({
        title: this.title,
        genre: this.genre
      })
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
