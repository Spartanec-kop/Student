import Vue from 'vue'
import Vuex from 'vuex'
import login from './modules/login'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    activeContent: ''
  },
  mutations: {
    SET_ACTIVE_CONTENT: (state, content) => (state.activeContent = content)
  },
  actions: {
    navigate ({ commit, dispatch }, content) {
      commit('SET_ACTIVE_CONTENT', content)
      dispatch('modal/closeModal')
      router.push({ path: content })
    }
  },
  modules: {
    login
  }
})
