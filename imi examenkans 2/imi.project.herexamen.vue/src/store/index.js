import { createStore } from 'vuex'

export default createStore({
  state: {
    menu_is_active: false,
  },
  getters: {
  },
  mutations: {
    TOGGLE_DROPDOWN(state, dir = null){
      if (dir === 'open'){
        state.menu_is_active = true
      }
      else if (dir === 'close') {
        state.menu_is_active = false
      }
      else {
        state.menu_is_active = !state.menu_is_active
      }
    },
  },
  actions: {
    ToggleDropDown({commit}){
      commit('TOGGLE_DROPDOWN')
    },

    CloseMenu({commit}){
      commit('TOGGLE_DROPDOWN', 'close')
    },
  },
  modules: {
  }
})
