import axios from '../../requests'

export default {
  namespaced: true,
  state: {
    students: {},
    filters: {
      fio: '',
      sex: null,
      nickName: '',
      groups: ''
    },
    checkedStudents: [],
    pageNumber: 1,
    pageSize: 3,
    isLoading: false
  },
  mutations: {
    SET_STUDENTS: (state, data) => (state.students = data),
    SET_FILTER: (state, filter) => {
      state.filters[filter.name] = filter.checkedFilter
    },
    SET_SORTING: (state, sorting) => (state.sorting = sorting),
    ADD_CHECKED_STUDENT: (state, item) => (state.checkedStudents.push(item)),
    REMOVE_CHECKED_STUDENT: (state, item) => {
      const id = state.checkedStudents.indexOf(item)
      state.checkedStudents.splice(id, 1)
    },
    CHECK_ALL_STUDENTS: (state) => (state.checkedStudents = [...state.students.rows]),
    CLEAR_CHECKED_STUDENT: state => (state.checkedStudents = [])
  },
  actions: {
    fetchStudents ({ commit, state }) {
      commit('SET_IS_LOADING', true)
      axios
        .get(`/api/students/?${state.filters.sex !== null ? `sex=${state.filters.sex}` : ''}&Fio=${state.filters.fio}&NickName=${state.filters.nickName}&GroupName=${state.filters.groups}&pageNumber=${state.pageNumber}&pageSize=${state.pageSize}`)
        .then(response => {
          commit('SET_STUDENTS', response.data)
          commit('SET_IS_LOADING', false)
        })
        .catch(error => {
          console.log(error.response)
        })
    },
    setFilter ({ commit }, filter) {
      commit('SET_FILTER', filter)
      commit('CLEAR_CHECKED_STUDENT')
    },
    checkStudent ({ commit }, data) {
      if (data.target) {
        commit('ADD_CHECKED_STUDENT', data.item)
      } else {
        commit('REMOVE_CHECKED_STUDENT', data.item)
      }
    },
    checkAllStudent ({ commit }, checked) {
      if (checked) {
        commit('CHECK_ALL_STUDENTS')
      } else {
        commit('CLEAR_CHECKED_STUDENT')
      }
    }
  },
  getters: {
  }
}
