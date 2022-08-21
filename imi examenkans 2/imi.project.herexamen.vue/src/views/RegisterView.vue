<template>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <main class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">

    <section>
      <h3 class="font-bold text-gray-800 text-2xl font-Exo">Register as a BSF-Member</h3>
      <p class="text-gray-700 font-Exo pt-2">Please fill out this registration form</p>
    </section>

    <section class="mt-10">
      <form @submit.prevent="handleRegistration" class="flex flex-col" method="POST" action="#">
        <div class="mb-6 pt-3 bg-gray-200 rounded-lg">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="email">Email</label>
          <input type="email" id="email" v-model="email" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200 rounded-lg">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="username">Username</label>
          <input type="text" id="username" v-model="username" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200 rounded-lg">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="password">Password</label>
          <input type="text" id="password" v-model="password" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition duration-500 px-3 pb-3">
        </div>
        <div class="pb-8">
          <input type="checkbox" id="termsAndConditions" v-model="termsAndConditions" value="Agreed">
          <label for="termsAndConditions" class="text-gray-800"> I have read and agree to the BSF Terms & Conditions</label>
        </div>
        <button class="bg-yellow-500 font-Exo h-8 hover:bg-yellow-600 text-gray-600 rounded shadow-lg hover:shadow-xl transition:duration-200" type="submit">Register</button>
      </form>
    </section>
  </main>
  <div class="max-w-lg mx-auto text-center mt-12 mb-6">
    <p class="text-white">To the <router-link to="/Login" class="font-bold hover:underline">Login</router-link> page ...</p>
  </div>
  </body>
</template>

<script>
import axios from "axios";
import router  from "@/router";
export default {
  name: "RegisterView",

  data() {
    return {
      email: '',
      username: '',
      password: '',
      termsAndConditions: false
    }
  },

  methods: {
    async handleRegistration() {
      const response = await axios.post('/Auth/Register', {
        email: this.email,
        username: this.username,
        password: this.password,
        termsAndConditions: this.termsAndConditions
      });

      console.log(response)
      await router.push('/login');
    }
  }
}
</script>

<style scoped>

</style>