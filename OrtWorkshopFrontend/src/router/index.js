import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/components/Main'
import List from '@/components/List'
import New from '@/components/New'
import Edit from '@/components/Edit'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Main',
      component: Main
    },
    {
      path: '/list',
      name: 'List',
      component: List
    },
    {
      path: '/new',
      name: 'New',
      component: New
    },
    {
      path: '/edit/:id',
      name: 'Edit',
      component: Edit
    }
  ]
})
