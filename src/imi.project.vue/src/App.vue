<template>
  <header>
    <nav>
    </nav>
  </header>
  <main>
    <HomePage/>
  </main>
</template>

<script>
import HomePage from './components/HomePage.vue';

export default {
  name: 'App',
  components: {
    HomePage,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
}
main{
  margin: 0 auto;
  padding: 30px;
  background-color: white;
  width: 1024px;
}
</style>
