<template>
  <Navbar/>
  <dropdown-menu/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <main class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">
    <section>
      <h3 class="font-bold text-gray-800 text-2xl font-Exo">Edit Combat Role</h3>
    </section>
    <section class="mt-10">
      <form class="flex flex-col" @submit.prevent="CreateCombatRole" method="POST" action="#">
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="name">Name</label>
          <input type="text" id="name" v-model="newCombatRole.name" :placeholder="oldCombatRole.name" required class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="description">Description</label>
          <textarea type="text" id="description" v-model="newCombatRole.description" :placeholder="oldCombatRole.description" required rows="3" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3"></textarea>
        </div>
        <button class="bg-yellow-500 font-Exo h-8 hover:bg-yellow-600 text-gray-600 rounded shadow-lg hover:shadow-xl transition:duration-200" type="submit">Update Combat Role</button>
      </form>
    </section>
    <div v-if="errorMessage" class="max-w-lg mx-auto text-center mt-12 mb-6">
      <p class="text-red-600">{{ errorMessage }}</p>
    </div>
  </main>
  </body>
</template>

<script>
import Navbar from "@/components/Navbar";
import router from "@/router";
import DropdownMenu from "@/components/DropdownMenu";
import CombatRoleService from "@/Services/CombatRoleService";

export default {
  name: "CombatRolesCreate.vue",
  data() {
    return {
      oldCombatRole: {},
      newCombatRole: {
        name: '',
        description: '',
      },
      submitted: false,
      errorMessage: '',
    }
  },

  methods: {
    CreateCombatRole() {
      var data = {
        Id: this.$route.params.id,
        Name: this.newCombatRole.name,
        Description: this.newCombatRole.description
      };
      CombatRoleService.update(this.$route.params.id, data).then(response => {
        console.log(response.data);
        this.resetCombatRole();
        router.push('/CombatRoles')

      }).catch(ex => {
        this.errorMessage = ex;
      });
    },

    resetCombatRole() {
      this.errorMessage = '';
      this.newCombatRole = {};
    },
  },

  mounted() {
    CombatRoleService.getById(this.$route.params.id).then(response => {
      console.log(response.data.data);
      this.oldCombatRole = response.data.data;
    })
  },

  components: {
    DropdownMenu,
    Navbar,
  }
}
</script>

<style scoped>

</style>