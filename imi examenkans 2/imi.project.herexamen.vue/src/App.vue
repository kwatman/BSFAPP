<template>
  <div class="bg-gray-700 min-h-screen text-white">
    <router-view/>
  </div>
</template>

<script>
import axios from "axios";

export default {

  async created() {
    const user = await axios.get('api/users/' + sessionStorage.getItem('currentUserId'));

    this.$store.dispatch('CurrentUser', user.data.data);
  },
}
</script>

<style>
.btn{
  @apply bg-yellow-500 duration-300 font-bold py-2 px-4 rounded-lg inline-block;
}

.btn:hover{
  @apply bg-yellow-600;
}

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
