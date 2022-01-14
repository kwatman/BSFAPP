<template>
  <HeaderComponent/>
  <main class="bg-glazed-pink">
    <HomePage/>
  </main>
</template>

<script>
import HomePage from './components/HomePage.vue';
import HeaderComponent from './components/HeaderComponent.vue';

export default {
  name: 'App',
  components: {
    HomePage,
    HeaderComponent,
  },
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Trocchi&display=swap');
</style>
