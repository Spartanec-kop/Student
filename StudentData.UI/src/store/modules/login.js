import axios from '../../requests'
import router from '../../router/index'

export default {
  namespaced: true,
  state: {
    user: localStorage.getItem('token') ? 'admin' : '',
    loginError: '',
    isLoading: false
  },
  mutations: {
    SET_USER: (state, data) => (state.user = data),
    SET_LOGIN_ERROR: (state, data) => (state.loginError = data.error.message),
    SET_IS_LOADING: (state, isLoading) => (state.isLoading = isLoading)
  },
  actions: {
    async setUser ({ commit }) {
      try {
        const { data } = await axios.get('/api/user')
        commit('SET_USER', data)
      } catch (e) {
        console.log(e)
        commit('SET_USER', {})
      }
    },
    logIn ({ commit }, loginData) {
      commit('SET_IS_LOADING', true)
      axios
        .get(`/api/User/auth?login=${loginData.login}&password=${loginData.password}`)
        .then(response => {
          commit('SET_IS_LOADING', false)
          localStorage.setItem('token', response.data)
          axios.defaults.headers.Authorization = `Bearer ${response.data}`
          router.push({ path: 'student' })
        })
        .catch(error => {
          console.log(error.response)
        })

      // setTimeout(() => {
      //   commit('SET_IS_LOADING', false)
      //   const success = true
      //   if (success) {
      //     const response = { data: { user: 'admin', token: 'qyuiqwuyriwqtwquiytbvsdjfvabsjk' } }
      //     localStorage.setItem('token', response.data.token)
      //     axios.defaults.headers.Authorization = `Bearer ${response.data.token}`
      //     commit('SET_USER', response.data)
      //     router.push({ name: 'Home' })
      //   } else {
      //     commit('SET_LOGIN_ERROR', { error: { message: 'ошибка авторизации' } })
      //   }
      // }, 2000)
    },
    logout ({ commit, dispatch }) {
      localStorage.removeItem('token')
      router.push({ name: 'Login' })
      commit('SET_USER', '')
    }
  },
  getters: {
    user (state) {
      return state.user
    }
  }
}
