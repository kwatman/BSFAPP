<template>
  <div class="bg-gray-700 min-h-screen text-white">
    <router-view :user="user"/>
  </div>
</template>

<script>
import {mapGetters} from "vuex";
import axios from "axios";

export default {

  computed: {
    ...mapGetters(['user'])
  },

  async created() {
    const user = await axios.get('api/users/' + sessionStorage.getItem('currentUserId'));

    this.$store.dispatch('CurrentUser', user.data.data);
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
