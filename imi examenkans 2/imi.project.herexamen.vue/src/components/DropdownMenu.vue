<template>
  <aside :class="`fixed top-0 left-0 min-h-screen pt-16 z-40 w-full max-w-xs transform duration-300 bg-gray-800
  ${menu_is_active ? 'translate-x-0' : '-translate-x-full'}`">
    <div class="p-4">
      <h2 class="text-gray-500 text-sm font-bold uppercase mb-3">
        Navigation
      </h2>
      <div class="-mx-4">
        <MenuItem to="/operations">
          <span class="material-icons mr-2">calendar_month</span> Operations
        </MenuItem>
        <MenuItem to="/maps">
          <span class="material-icons mr-2">map</span> Maps
        </MenuItem>
        <MenuItem to="/combatroles">
          <span class="material-icons mr-2">military_tech</span> Combat Roles
        </MenuItem>
        <MenuItem to="/members">
          <span class="material-icons mr-2">group</span> Members
        </MenuItem>
        <MenuItem to="/kanyerest">
          <span class="material-icons mr-2">format_quote</span> Kanye REST
        </MenuItem>
      </div>
    </div>
  </aside>
</template>

<script>
import {useStore} from "vuex";
import {computed} from "vue";
import MenuItem from "@/components/MenuItem";

export default {
  components: {MenuItem},
  setup() {
    const store = useStore()

    return {
      menu_is_active: computed(() => store.state.menu_is_active)
    }
  }
}
</script>