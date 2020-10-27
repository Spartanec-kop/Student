import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    name: 'Login',
    component: () => import(/* webpackChunkName: 'about' */ '../views/Login.vue')
  }
]

const router = new VueRouter({
  routes
})

async function isAuthentificated () {
  let result = false
  if (localStorage.getItem('token')) {
    await store.dispatch('login/setUser')
    if (store.getters['login/user']) {
      result = true
    } else {
      result = false
    }
  } else {
    result = false
  }
  return result
}

router.beforeEach((to, from, next) => {
  if (to.path !== '/login') {
    isAuthentificated().then(result => {
      if (!result) {
        next('/login')
      } else {
        next()
      }
    })
  } else {
    isAuthentificated()
      .then(result => {
        if (result) {
          next('/')
        } else {
          next()
        }
      })
      .catch(e => {
        console.log(e)
      })
  }
})

export default router
