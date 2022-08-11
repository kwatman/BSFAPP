<template>
  <main class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">
      <section class="">
      <h3 class="">Welcome to BSF-Network</h3>
      <p class="">Log in to your account</p>
    </section>
    <section class="">
      <form class="" method="POST" action="#">
        <div class="">
          <label class="" for="username">Username</label>
          <input type="text" id="username" class="">
        </div>
        <div class="">
          <label class="" for="password">Password</label>
          <input type="text" id="password" class="">
        </div>
        <button class="" type="submit">Log In</button>
      </form>
    </section>
    <div class="">
      <p class="">Don't have anm account yet? <router-link to="/Register" class="">Register</router-link>.</p>
    </div>
  </main>
</template>

<script>
export default {
  name: "LoginView.vue"
}
</script>

<style scoped>

</style>