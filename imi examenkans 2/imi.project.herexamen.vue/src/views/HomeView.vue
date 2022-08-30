<template>
  <Navbar :user="user" class="sticky top-0 z-50"/>
  <dropdown-menu/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">

  <div class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">
    <h3 v-if="user" class="font-bold text-gray-800 text-2xl font-Exo">Welcome {{user.userName}}!</h3>
    <h3 v-if="!user" class="font-bold text-gray-800 text-2xl font-Exo">Please log in</h3>
  </div>
  </body>
</template>

<script>
import Navbar from "@/components/Navbar";
import DropdownMenu from "@/components/DropdownMenu";
import {useStore} from "vuex";

export default {
  name: 'HomeView',

  setup(){
    const store = useStore();
    const user = store.getters.user;

    return{
      user
    }
  },

  components: {
    Navbar,
    DropdownMenu
  },
}
</script>
