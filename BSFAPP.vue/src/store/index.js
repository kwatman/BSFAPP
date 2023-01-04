import { createStore } from 'vuex'

export default createStore({
  state: {
    menu_is_active: false,
    user: null
  },
  getters: {
    user: (state) => {return state.user}
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

    USER(state, user){
      state.user = user;
    }
  },
  actions: {
    ToggleDropDown({commit}){
      commit('TOGGLE_DROPDOWN')
    },

    CloseMenu({commit}){
      commit('TOGGLE_DROPDOWN', 'close')
    },

    CurrentUser(context, user){
      context.commit('USER', user)
    }
  },
  modules: {
  }
})
