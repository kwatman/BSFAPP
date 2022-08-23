<template>
<header class="flex w-full items-center justify-center p-4 bg-gray-800 shadow-2xl">
  <div :class="`menu-toggle relative z-50 ${
    menu_is_active
    ? 'is-active'
    : ''
  }`"
  @click="ToggleDropDown">
    <div class="hamburger">
      <span></span>
    </div>
  </div>
  <img src="../assets/shield2-min.png" alt="BSF Coat of Arms" class=" ml-auto pl-24 h-20 w-38"/>
  <div class="pl-3">
    <h1 class="text center text-lg uppercase font-light tracking-widest font-Exo">
      Belgian Special Forces
    </h1>
    <h2 class="text center text-1xl uppercase font-light tracking-widest font-Exo">
      Milsim Community
    </h2>
  </div>
  <div v-if="!user" class="flex ml-auto justify-between items-center space-x-8">
    <div class="flex items-center space-x-3">
      <router-link to="/login" class="text-white font-Exo hover:text-gray-400">Log In</router-link>
      <p class="text-white font-Exo font-bold">|</p>
      <router-link to="/register" class="text-white font-Exo hover:text-gray-400">Register</router-link>
    </div>
  </div>
  <div v-if="user" class="flex ml-auto justify-between items-center space-x-8">
    <a href="javascript:void(0)" @click="handleLogout">Log Out</a>
  </div>
</header>
</template>

<script>
import {computed} from "vue"
import {useStore} from 'vuex'
import router from "@/router";

export default {
  methods: {
    handleLogout() {
      sessionStorage.removeItem('token');
      sessionStorage.removeItem('currentUserId')
      this.$store.dispatch('user', null)
      router.push('/login');
    }
  },

  setup(){
    const store = useStore()
    const user = store.getters.user;
    const ToggleDropDown = () => {
      store.dispatch('ToggleDropDown')
    }

    return{
      menu_is_active: computed(() => store.state.menu_is_active),
      ToggleDropDown,
      user
    }
  },
  name: "Navbar-vue"
}
</script>

<style scoped>
:deep(.menu-toggle){
  position:absolute;
  top: 2rem;
  left: 2rem;
  width: 32px;
  height: 32px;
  cursor: pointer;
}

.hamburger{
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 32px;
  height: 32px;
}

.hamburger span{
  top: 50%;
  transform: translateY(-50%);
}

.hamburger span,
.hamburger span:before,
.hamburger span:after{
  position: absolute;
  width: 100%;
  height: 4px;
  border-radius: 99px;
  background-color: white;
  transition: all 0.3s ease-in-out;
}

.hamburger span:before,
.hamburger span:after{
  content: '';
}

.hamburger span:before{
  top: -8px;
}

.hamburger span:after{
  top: 8px;
}

.menu-toggle.is-active .hamburger > span{
  transform: rotate(45deg);
}

.menu-toggle.is-active .hamburger > span:before{
  top: 0;
  transform: rotate(0deg);
}

.menu-toggle.is-active .hamburger > span:after{
  top: 0;
  transform: rotate(90deg);
}
</style>