<template>
  <Navbar/>
  <ul class="w-48 text-sm font-medium text-gray-900 bg-white rounded-lg border border-gray-200 dark:bg-gray-700 dark:border-gray-600 dark:text-white">
    <li class="py-2 px-4 w-full rounded-t-lg border-b border-gray-200 dark:border-gray-600"
        :class="{ active: index == selectedIndex }"
        v-for="(combatRole, index) in combatRoles"
        :key="index"
        @click="setActiveMap(combatRole, index)">{{ combatRole.name }}</li>
  </ul>
</template>

<script>
import CombatRoleService from "@/Services/CombatRoleService";
import Navbar from "@/components/Navbar";

export default {
  data() {
    return {
      combatRoles: [],
      selectedCombatRole: null,
      selectedIndex: -1,
    }
  },
  methods: {
    GetCombatRoles() {
      CombatRoleService.getAll().then(response => {
        this.maps = response.data.data;
        console.log(response.data.data)
      })
    },

    refreshList() {
      this.GetCombatRoles();
      this.selectedCombatRole = null;
      this.selectedIndex = -1;
    },

    setActiveMap(combatRole, index) {
      this.selectedCombatRole = combatRole;
      this.selectedIndex = combatRole ? index : -1
    }
  },
  mounted() {
    this.GetCombatRoles()
  },
  components : {
    Navbar
  }
}
</script>

<style scoped>

</style>