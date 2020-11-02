import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'
// глобальная регистрация базовых компонентов
import './components/base/_globals'
import Multiselect from 'vue-multiselect'

Vue.config.productionTip = false
Vue.component('multiselect', Multiselect)
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
