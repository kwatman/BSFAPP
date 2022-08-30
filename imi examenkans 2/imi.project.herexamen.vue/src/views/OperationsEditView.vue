<template>
  <Navbar/>
  <dropdown-menu/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <main class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">
    <section>
      <h3 class="font-bold text-gray-800 text-2xl font-Exo">Edit Operation</h3>
    </section>
    <section class="mt-10">
      <form class="flex flex-col" @submit.prevent="UpdateOperation" method="POST" action="#">
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="codename">Operation Codename</label>
          <input type="text" id="codename" v-model="newOperation.codeName" :placeholder="oldOperation.codeName" required class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="zerohour">Zero Hour</label>
          <input type="datetime-local" id="zerohour" v-model="newOperation.zeroHour" :placeholder="oldOperation.zeroHour" required class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
        </div>
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="sitrep">SITREP</label>
          <textarea type="text" id="sitrep" v-model="newOperation.sitrep" :placeholder="oldOperation.sitrep" required rows="3" class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3"></textarea>
        </div>
        <div class="mb-6 pt-3 bg-gray-200">
          <label class="block text-gray-700 text-sm font-bold font-Exo mb-2 ml-3" for="map">A.O.</label>
          <select type="text" id="map" v-model="newOperation.map" required class="bg-gray-200 rounded w-full text-gray-700 focus:outline-none border-b-4 border-gray-300 focus:border-yellow-500 transition:duration-500 px-3 pb-3">
            <option v-for="map in maps" :key="map.id" :value="map.id">{{ map.name }}</option>
          </select>
        </div>
        <button class="bg-yellow-500 font-Exo h-8 hover:bg-yellow-600 text-gray-600 rounded shadow-lg hover:shadow-xl transition:duration-200" type="submit">Update Operation</button>
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
import OperationService from "@/Services/OperationService";
import MapService from "@/Services/MapService";
import router from "@/router";
import DropdownMenu from "@/components/DropdownMenu";

export default {
  name: "OperationsEdit.vue",
  data() {
    return {
      maps: [],
      oldOperation: {},
      newOperation: {
        codeName: "",
        sitrep: "",
        zeroHour: "",
        map: {},
      },
      submitted: false,
      errorMessage: '',
    }
  },

  methods: {
    UpdateOperation() {
      var data = {
        Id: this.$route.params.id,
        CodeName: this.newOperation.codeName,
        Sitrep: this.newOperation.sitrep,
        ZeroHour: this.newOperation.zeroHour,
        MapId: this.newOperation.map
      };
      OperationService.update(this.$route.params.id, data).then(response => {
        console.log(response.data);
        this.resetOperation();
        router.push('/Operations')

      }).catch(ex => {
        this.errorMessage = ex;
      });
    },

    resetOperation() {
      this.errorMessage = '';
      this.operation = {};
    },

    GetMaps() {
      MapService.getAll().then(response => {
        this.maps = response.data.data;
        console.log(response.data.data)
      }).catch(ex => this.errorMessage = ex)
    }
  },

  mounted() {
    OperationService.getById(this.$route.params.id).then(response => {
      console.log(response.data.data);
      this.oldOperation = response.data.data;
    })

    this.GetMaps();
  },

  components: {
    DropdownMenu,
    Navbar,
  }
}
</script>

<style scoped>

</style>