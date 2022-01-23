<template>
  <HeaderComponent/>
  <main class="bg-glazed-pink">
    <router-view/>
  </main>
</template>

<script>
import HeaderComponent from './components/HeaderComponent.vue';

export default {
  name: 'App',
  components: {
    HeaderComponent,
  },
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Trocchi&display=swap');
</style>
