<template>
  <Navbar></Navbar>
  <div class="min-w-screen min-h-screen bg-gray-700 flex items-center justify-center px-5 py-5">
    <div class="w-full mx-auto rounded-lg bg-gray-300 shadow-lg px-5 pt-5 pb-10 text-gray-800" style="max-width: 500px">
      <div class="w-full pt-1 pb-5">
        <div class="overflow-hidden rounded-full w-20 h-20 -mt-16 mx-auto shadow-lg">
          <img src="../assets/kanye.jpg" alt="Kanye">
        </div>
      </div>
      <div class="w-full mb-10">
        <div class="text-3xl text-yellow-500 text-left leading-tight h-3">“</div>
        <p class="text-lg text-gray-600 text-center px-5">{{ quote }}</p>
        <div class="text-3xl text-yellow-500 text-right leading-tight h-3 -mt-3">”</div>
      </div>
      <div class="w-full">
        <p class="text-md text-Black font-bold text-center">- Kanye West</p>
      </div>
      <div class="items-center pt-4">
        <button @click="Reload" class="btn">Another one!</button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue'
import Navbar from "@/components/Navbar";

export default {
  setup() {
    const quote = ref('')

    axios.get('https://api.kanye.rest/').then(response => {
      quote.value = response.data.quote
    })
    return {
      quote
    }
  },
  methods: {
    Reload() {
      window.location.reload();
    }
  },
  components : {
    Navbar
  }
}
</script>

<style scoped>

</style>