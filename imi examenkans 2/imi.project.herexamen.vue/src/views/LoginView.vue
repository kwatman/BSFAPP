<template>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <main class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">

    <section>
      <h3 class="font-bold text-gray-800 text-2xl font-Exo">Welcome to BSF-Network</h3>
      <p class="text-gray-700 font-Exo pt-2">Log in to your account</p>
    </section>

    <section class="mt-10">
      <form class="flex flex-col" method="POST" action="#">
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="username">Username</label>
          <input type="text" id="username" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="password">Password</label>
          <input type="text" id="password" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition duration-500 px-3 pb-3">
        </div>
        <button class="bg-yellow-500 font-Exo h-8 hover:bg-yellow-600 text-gray-600 rounded shadow-lg hover:shadow-xl transition:duration-200" type="submit">Log In</button>
      </form>
    </section>
  </main>
  <div class="max-w-lg mx-auto text-center mt-12 mb-6">
    <p class="text-white">Don't have anm account yet? <router-link to="/Register" class="font-bold hover:underline">Register</router-link>.</p>
  </div>
  </body>
</template>

<script>
export default {
  name: "LoginView.vue"
}
</script>

<style scoped>

</style>