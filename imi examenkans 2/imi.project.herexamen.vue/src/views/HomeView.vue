<template>
  <div class="bg-gray-700 min-h-screen text-white">
    <Navbar :user="user" class="sticky top-0 z-50"/>
    <DropdownMenu/>
    <h3 v-if="user">Welcome {{user.userName}}</h3>
    <h3 v-if="!user">Please log in</h3>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar";
import DropdownMenu from "@/components/DropdownMenu";
import {mapGetters} from "vuex";

export default {
  name: 'HomeView',

  components: {
    Navbar,
    DropdownMenu
  },

  computed: {
    ...mapGetters(['user'])
  }
}
</script>
