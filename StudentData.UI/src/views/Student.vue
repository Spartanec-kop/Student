<template lang="pug">
.student-table-wrapper
  table.student-table
    thead
      th.select-all
        BaseCheckbox(
          v-model="selectAll"
        )
      th
        .column-header
          .column-header-title Ф.И.О.
          input.filter.fio-filter(
            type="text"
            v-model="fio"
            @input="changeFilter"
          )
      th
        .column-header
          .column-header-title Пол
          select.filter.sex-filter(
            v-model="sex"
            @change="changeFilter"
          )
            option(
              :value="null"
            ) Все
            option(
              :value="true"
            ) Муж.
            option(
              :value="false"
            ) Жен.
      th
        .column-header
          .column-header-title Прозвище
          input.filter.nickName-filter(
            type="text"
            v-model="nickName"
            @input="changeFilter"
          )
      th
        .column-header
          .column-header-title Группы
          input.filter.groups-filter(
            type="text"
            v-model="groups"
            @input="changeFilter"
          )
    tbody
      tr(
        v-for="student in students.rows"
        :class="{'selected-row': checkRow(checkedStudents, student)}"
        :key="student.Id"
      )
        td.checkbox-cell
          BaseCheckbox(
            :checked="checkRow(checkedStudents, student)"
            @change="checkStudent({target:$event, item: student })"
          )
        td {{student.fio}}
        td {{student.sex ? 'муж.' : 'жен.'}}
        td {{student.nickName}}
        td {{student.groups}}
  .students-footer
    Paginator(
      :pageNumber="students.pageNumber"
      :pageCount="students.pageCount"
      @navigate="setPageNumber"
    )
    .add-student(
      @click.stop="showModal({ component: 'StudentCreate', showClose: false })"
    )
      img.plus(
        src="../../public/img/icons/plus.svg"
      )
      .add-subnet-title Добавить студента
</template>
<script>
import { mapState, mapActions } from 'vuex'
import Paginator from '../components/Paginator'
export default {
  name: 'Student',
  components: {
    Paginator
  },
  data () {
    return {
      fio: '',
      sex: null,
      nickName: '',
      groups: ''
    }
  },
  computed: {
    ...mapState('student', {
      students: state => state.students,
      checkedStudents: state => state.checkedStudents
    }),
    filtersData () {
      return null
    },
    selectAll: {
      get () {
        return Object.keys(this.students).length > 0 && this.students.rows.length === this.checkedStudents.length
      },
      set (checked) {
        this.checkAllStudent(checked)
      }
    }
  },
  methods: {
    ...mapActions('student', ['fetchStudents', 'checkStudent', 'checkAllStudent', 'setFilters', 'setPageNumber']),
    ...mapActions('modal', ['showModal']),
    checkRow (checkedStudents, student) {
      return checkedStudents.indexOf(student) + 1 > 0
    },
    changeFilter () {
      this.setFilters({ fio: this.fio, sex: this.sex, nickName: this.nickName, groups: this.groups })
    }
  },
  mounted () {
    this.fetchStudents()
  }
}
</script>
<style lang="scss" scoped>
.student-table-wrapper {
  padding-top:30px;
  width: 80%;
  min-height: 400px;
  overflow-y: auto;
  margin: 0 auto;
  min-width: 500px;
  color: black;
}
.select-all {
  padding-left: 30px;
}
thead {
  background: #F2F2F2;
  border-radius: 3px;
}
table {
  border-spacing: 0px;
  width: 100%;
}
td, th {
  border: 0.5px solid #BCBCBC;
}
th {
  height: 36px;
  max-width: 200px;
}
tr {
  height: 30px;
}
td {
  padding: 0px 15px;
}
.checkbox-cell {
  width: 25px;
  padding: 0px 30px;
}
.column-header {
  position: relative;
  padding: 0px 10px;
}
.selected-row {
  background: #d6e1ff;
}
.filter{
  width: 100%;
  height: 24px;
  background: #F9F9F9;
  border: 1px solid #C8C8C8;
  box-sizing: border-box;
  border-radius: 5px;
  text-align: center;

  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 13px;
  line-height: 15px;
  color: #333333;
}
.students-footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.add-student {
  display: flex;
  justify-content: space-between;
  align-items: center;
  cursor: pointer;
  font-family: Roboto;
  font-style: normal;
  font-weight: normal;
  font-size: 12px;
  line-height: 14px;
  color: #969696;
}
</style>
