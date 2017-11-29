<template>
  <div id="app">
    <a class="navigation" href="#/list">List</a>
    <a class="navigation" href="#/new">New</a>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>

<style>
body {
  margin: 0px;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  padding-top: 60px;
  background: linear-gradient(#CCCCCC, #FFFFFF);
  height: 100%;
}
label {
  display: inline-block;
  font-weight: bold;
  margin-right: 10px;
  width: 100px;
}
input {
  width: 200px;
}
.form {
  padding-left: 200px;
  padding-right: 200px;
}
button {
  margin: 10px;
}
a {
  color: #027943;
}
.navigation {
  font-size: 30px;
  margin-left: 10px;
  margin-right: 10px;
  text-decoration: none;
}
</style>
