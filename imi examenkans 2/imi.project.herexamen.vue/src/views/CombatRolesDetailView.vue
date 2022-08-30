<template>
  <Navbar/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <button @click="$router.back()" class="flex items-center text-lg text-white hover:text-red-600 duration-300 mb-8 ml-36">
    <span class="material-icons text-lg mr-1">keyboard_double_arrow_left</span> Return
  </button>
  <div class="bg-white shadow overflow-hidden sm:rounded-lg ml-40 mr-40">
    <div class="px-4 py-5 sm:px-6 text-left">
      <h3 class="text-lg leading-6 font-medium text-gray-900 pl-28">{{combatRole.name}}</h3>
      <p class="mt-1 max-w-2xl text-sm text-gray-500 pl-28">Combat Role Details</p>
    </div>
    <div class="border-t border-gray-200">
      <dl>
        <div class="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Name</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{combatRole.codeName}}</dd>
        </div>
        <div class="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Description</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{combatRole.description}}</dd>
        </div>
      </dl>
    </div>
  </div>
  </body>
</template>

<script>
import Navbar from "@/components/Navbar";
import CombatRoleService from "@/Services/CombatRoleService";
export default {
  name: "CombatRolesDetailView.vue",

  data() {
    return {
      combatRole: {},
      members: []
    }
  },

  mounted() {
    CombatRoleService.getById(this.$route.params.id).then(response => {
      console.log(response.data.data);
      this.combatRole = response.data.data;
    })
  },

  components: {
    Navbar
  }
}
</script>

<style scoped>

</style>