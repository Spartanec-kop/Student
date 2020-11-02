import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    groups: {},
    filters: {
      name: ''
    },
    checkedGroups: [],
    pageNumber: 1,
    pageSize: 10,
    isLoading: false
  },
  mutations: {
    SET_GROUPS: (state, data) => (state.groups = data),
    SET_FILTERS: (state, filters) => {
      state.filters = filters
    },
    ADD_CHECKED_GROUP: (state, item) => (state.checkedGroups.push(item)),
    REMOVE_CHECKED_GROUP: (state, item) => {
      const id = state.checkedGroups.indexOf(item)
      state.checkedGroups.splice(id, 1)
    },
    CHECK_ALL_GROUPS: (state) => (state.checkedGroups = [...state.groups.rows]),
    CLEAR_CHECKED_GROUPS: state => (state.checkedGroups = []),
    SET_PAGE_NUMBER: (state, pageNumber) => (state.pageNumber = pageNumber)
  },
  actions: {
    fetchGroups ({ commit, state }) {
      axios
        .get(`/api/Groups/?name=${state.filters.name}&pageNumber=${state.pageNumber}&pageSize=${state.pageSize}`)
        .then(response => {
          commit('SET_GROUPS', response.data)
        })
        .catch(error => {
          console.log(error.response)
        })
    },
    fetchSelectorGroups ({ commit, state }) {
      axios
        .get(`/api/Groups/?name=${state.filters.name}&pageNumber=0&pageSize=0`)
        .then(response => {
          commit('SET_GROUPS', response.data)
        })
        .catch(error => {
          console.log(error.response)
        })
    },
    setFilters ({ commit, dispatch }, filters) {
      commit('SET_GROUPS', filters)
      dispatch('fetchGroups')
      commit('CLEAR_CHECKED_GROUPS')
    },
    setSelectorFilters ({ commit, dispatch }, filters) {
      commit('SET_GROUPS', filters)
      dispatch('fetchSelectorGroups')
      commit('CLEAR_CHECKED_GROUPS')
    },
    checkGroup ({ commit }, data) {
      if (data.target) {
        commit('ADD_CHECKED_GROUP', data.item)
      } else {
        commit('REMOVE_CHECKED_GROUP', data.item)
      }
    },
    checkAllGroups ({ commit }, checked) {
      if (checked) {
        commit('CHECK_ALL_GROUPS')
      } else {
        commit('CLEAR_CHECKED_GROUPS')
      }
    },
    setPageNumber ({ commit, dispatch }, pageNumber) {
      commit('SET_PAGE_NUMBER', pageNumber)
      dispatch('fetchStudents')
    }
  },
  getters: {
  }
}
