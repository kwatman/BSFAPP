<template>
  <Navbar/>
  <dropdown-menu/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">
  <button @click="$router.back()" class="flex items-center text-lg text-white hover:text-red-600 duration-300 mb-8 ml-36">
    <span class="material-icons text-lg mr-1">keyboard_double_arrow_left</span> Return
  </button>
  <div class="bg-white shadow overflow-hidden sm:rounded-lg ml-40 mr-40">
    <div class="px-4 py-5 sm:px-6 text-left">
      <h3 class="text-lg leading-6 font-medium text-gray-900 pl-28">Operation {{operation.codeName}}</h3>
      <p class="mt-1 max-w-2xl text-sm text-gray-500 pl-28">Mission details and briefing</p>
    </div>
    <div class="border-t border-gray-200">
      <dl>
        <div class="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Codename</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{operation.codeName}}</dd>
        </div>
        <div class="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Zero Hour</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{FormatDate(operation.zeroHour)}}</dd>
        </div>
        <div class="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">A.O.</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{map.name}}</dd>
        </div>
        <div class="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Participants</dt>
          <ul class="sm:mt-0 sm:col-span-2">
            <li v-for="(participant, index) in participants" :key="index"><dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{ participant.userName}}</dd></li>
          </ul>
        </div>
        <div class="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
          <dt class="text-sm font-medium text-gray-500">Sitrep</dt>
          <dd class="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">{{operation.sitrep}}</dd>
        </div>
      </dl>
    </div>
  </div>
  <button class="bg-yellow-500 mt-8 w-48 h-8 hover:bg-yellow-600 text-gray-600 rounded shadow-lg hover:shadow-xl transition:duration-200" @click="Participate">Enlist</button>
  </body>
</template>

<script>
import OperationService from "@/Services/OperationService";
import Navbar from "@/components/Navbar";
import {FormatDate} from "@/utilities";
import axios from 'axios';
import DropdownMenu from "@/components/DropdownMenu";
export default {
  name: "OperationsDetailView.vue",

  data() {
    return {
      operation: {},
      map: {},
      participants: {}
    }
  },

  mounted() {
    OperationService.getById(this.$route.params.id).then(response => {
      console.log(response.data.data);
      this.operation = response.data.data;
      this.map = response.data.data.map;
      this.participants = response.data.data.participants
    })
  },

  methods: {
    Participate(){
      var data = {
        userId: sessionStorage.getItem('currentUserId'),
        operationId: this.$route.params.id,
      }
      axios.post('/api/Participations', data)
      window.location.reload();
    }
  },

  setup() {
    return {
      FormatDate
    }
  },

  components: {
    DropdownMenu,
    Navbar
  }
}
</script>

<style scoped>

</style>