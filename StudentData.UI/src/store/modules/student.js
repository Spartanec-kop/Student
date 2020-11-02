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
    pageSize: 10,
    isLoading: false
  },
  mutations: {
    SET_STUDENTS: (state, data) => (state.students = data),
    SET_FILTERS: (state, filters) => {
      state.filters = filters
    },
    ADD_CHECKED_STUDENT: (state, item) => (state.checkedStudents.push(item)),
    REMOVE_CHECKED_STUDENT: (state, item) => {
      const id = state.checkedStudents.indexOf(item)
      state.checkedStudents.splice(id, 1)
    },
    CHECK_ALL_STUDENTS: (state) => (state.checkedStudents = [...state.students.rows]),
    CLEAR_CHECKED_STUDENT: state => (state.checkedStudents = []),
    SET_PAGE_NUMBER: (state, pageNumber) => (state.pageNumber = pageNumber)
  },
  actions: {
    fetchStudents ({ commit, state }) {
      axios
        .get(`/api/students/?${state.filters.sex !== null ? `sex=${state.filters.sex}` : ''}&Fio=${state.filters.fio}&NickName=${state.filters.nickName}&GroupName=${state.filters.groups}&pageNumber=${state.pageNumber}&pageSize=${state.pageSize}`)
        .then(response => {
          commit('SET_STUDENTS', response.data)
        })
        .catch(error => {
          console.log(error.response)
        })
    },
    setFilters ({ commit, dispatch }, filters) {
      commit('SET_FILTERS', filters)
      dispatch('fetchStudents')
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
    },
    setPageNumber ({ commit, dispatch }, pageNumber) {
      commit('SET_PAGE_NUMBER', pageNumber)
      dispatch('fetchStudents')
    },
    createStudent ({ commit, dispatch }, student) {
      axios
        .post('/api/students/', {
          Sex: student.sex,
          LastName: student.lastName,
          Name: student.name,
          MiddleName: student.middleName,
          NickName: student.nickName
        })
        .then(response => {
          commit('ADD_STUDENT', response.data)
          dispatch('modal/closeModal', null, { root: true })
        })
        .catch(error => {
          console.log(error.response)
        })
    }
  },
  getters: {
  }
}
