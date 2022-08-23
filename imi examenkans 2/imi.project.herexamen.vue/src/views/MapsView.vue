<template>
  <Navbar/>
  <div class="flex flex-row">
    <div class="basis-1/3">
      <ul class="w-48 text-sm font-medium text-gray-900 bg-white rounded-lg border border-gray-200 dark:bg-gray-700 dark:border-gray-600 dark:text-white">
        <li class="py-2 px-4 w-full rounded-t-lg border-b border-gray-200 dark:border-gray-600"
            :class="{ active: index == selectedIndex }"
            v-for="(map, index) in maps"
            :key="index"
            @click="setActiveMap(map, index)">{{ map.name }}</li>
      </ul>
    </div>
    <div class="basis-2/3">

    </div>
  </div>
</template>

<script>
import MapService from "@/Services/MapService";
import Navbar from "@/components/Navbar";

export default {
  data() {
    return {
      maps: [],
      selectedMap: null,
      selectedIndex: -1,
    }
  },
  methods: {
    GetMaps() {
      MapService.getAll().then(response => {
        this.maps = response.data.data;
        console.log(response.data.data)
      })
    },

    refreshList() {
      this.GetMaps();
      this.selectedMap = null;
      this.selectedIndex = -1;
    },

    setActiveMap(map, index) {
      this.selectedMap = map;
      this.selectedIndex = map ? index : -1
    }
  },
  mounted() {
    this.GetMaps()
  },
  components : {
    Navbar
  }
}
</script>

<style scoped>

</style>