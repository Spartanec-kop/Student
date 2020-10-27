<template lang="pug">
  #app
    ModalWindow(
      v-if="showModal"
    )
    .header(
      v-if="user"
    )
      Header
    .body-wrapper
      router-view
</template>
<script>
import ModalWindow from './components/modalWindows/ModalWindow'
import Header from './components/Header'
import { mapState } from 'vuex'
export default {
  components: { Header, ModalWindow },
  data () {
    return {
      isAuthorized: true
    }
  },
  computed: {
    ...mapState('login', {
      user: state => state.user
    }),
    ...mapState('modal', {
      showModal: state => state.showModal
    })
  },
  methods: {
  }
}
</script>
<style lang="scss">
/* Fonts */
@font-face {
  font-family:Roboto;
  src:url("../public/fonts/roboto/Roboto.ttf") format("truetype");
  }
/* End fonts */
body {
  margin: 0px;
}
ul {
  list-style-type: none;
  padding: 0px;
  margin: 0px;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

</style>
