<template>
  <Navbar/>
  <body class="body-bg min-h-screen pt-12 md:pt-20 pb-6 px-2 md:px-0">

  <div v-if="errorMessage" class="bg-white max-w-lg mx-auto p-8 md:p-12 my-10 rounded-lg shadow-2xl">
    <h3 class="font-bold text-gray-800 text-2xl font-Exo">Error</h3>
    <p class="text-gray-700 font-Exo pt-2">{{ errorMessage }}</p>
  </div>

  <div v-if="operations.length > 0" class="container max-w-7cl mx-auto mt-8">
    <h1 class="font-Exo text-3xl decoration-gray-400">Operations</h1>
    <div class="flex justify-end pb-10 pr-20">
      <router-link :to="{name: 'OperationsCreate'}"><button class="px-4 py-2 rounded-md bg-yellow-500 text-white hover: bg-yellow-400">Add Operation</button></router-link>
    </div>
  </div>
  <div v-if="operations.length > 0" class="flex flex-col pl-10 pr-10">
    <div class="overflow-x-auto sm:-px-6 lg:-mx-8 lg:px-8">
      <div class="inline-block min-w-full overflow-hidden align-middle border-b border-gray-200 shadow sm:rounded-lg">
        <table class="min-w-full">
          <thead>
          <tr>
            <th class="px-6 py-3 text-xs text-center font-medium leading-4 tracking-wider text-left text-gray-500 uppercase border-b border-gray-200 bg-gray-50">Codename</th>
            <th class="px-6 py-3 text-sm text-center text-gray-500 border-b border-gray-200 bg-gray-50">Actions</th>
          </tr>
          </thead>
          <tbody class="bg-white">
          <tr :class="{ active: index == selectedIndex }" v-for="(operation, index) in operations"
              :key="index"
              @click="setActiveMap(operation, index)">
            <td class="px-6 py-4 whitespace-nowrap border-b border-gray-200">
              <div class="flex-items-center text-black">
                {{ operation.codeName }}
              </div>
            </td>
            <td class="px-6 py-4 whitespace-nowrap border-b border-gray-200">
              <div class="flex-items-center text-black">
                <router-link :to="{ name: 'OperationDetails', params: { id: operation.id }}"><span class="material-icons text-blue-600">visibility</span></router-link>
                <span class="material-icons text-green-600">edit</span>
                <span class="material-icons text-red-600">delete</span>
              </div>
            </td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  </body>
</template>

<script>
import OperationService from "@/Services/OperationService";
import Navbar from "@/components/Navbar";

export default {
  data() {
    return {
      operations: [],
      selectedOperation: null,
      selectedIndex: -1,
      errorMessage: null,
    }
  },
  methods: {
    GetOperations() {
      OperationService.getAll().then(response => {
        this.operations = response.data.data;
        console.log(response.data.data)
      }).catch(ex => this.errorMessage = ex)
    },

    refreshList() {
      this.GetOperations();
      this.selectedOperation = null;
      this.selectedIndex = -1;
    },

    setActiveMap(operation, index) {
      this.selectedOperation = operation;
      this.selectedIndex = operation ? index : -1
    }
  },
  mounted() {
    this.GetOperations()
  },
  components : {
    Navbar
  }
}
</script>

<style scoped>

</style>