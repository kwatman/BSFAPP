<template>
  <div class="bg-gray-700 min-h-screen text-white">
    <Navbar class="sticky top-0 z-50"/>
    <DropdownMenu/>
    <router-link to="/Login">To Login</router-link>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar";
import DropdownMenu from "@/components/DropdownMenu";

export default {
  name: 'HomeView',

  components: {
    Navbar,
    DropdownMenu
  },
}
</script>
