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
      th
        .column-header
          .column-header-title Пол
      th
        .column-header
          .column-header-title Прозвище
      th
        .column-header
          .column-header-title Группы
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
</template>
<script>
import { mapState, mapActions } from 'vuex'
export default {
  name: 'Student',
  components: {},
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
    ...mapActions('student', ['fetchStudents', 'checkStudent', 'checkAllStudent']),
    checkRow (checkedStudents, student) {
      return checkedStudents.indexOf(student) + 1 > 0
    }
  },
  mounted () {
    this.fetchStudents()
  }
}
</script>
<style lang="scss" scoped>
.student-table-wrapper {
  width: 100%;
  min-height: 400px;
  overflow-y: auto;
}
.select-all {
  padding-left: 7px;
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
  padding: 0px 35px;
}
.checkbox-cell {
  width: 35px;
  padding: 0px 7px;
}
.column-header {
  position: relative;
  padding: 0px 10px;
}
.selected-row {
  background: #FFECD6;
}
</style>
