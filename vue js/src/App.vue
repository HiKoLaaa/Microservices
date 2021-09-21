<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <div class="row justify-content-center">
      <div class="col-6">
        <router-link to="/users" class="btn btn-danger p-2">User list</router-link>
      </div>
    </div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
