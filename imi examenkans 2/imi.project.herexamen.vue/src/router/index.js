import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/Login',
    name: 'Login',
    component: () => import('../views/LoginView')
  },
  {
    path: '/Register',
    name: 'Register',
    component: () => import('../views/RegisterView.vue')
  },
  {
    path: '/Maps',
    name: 'Maps',
    component: () => import('../views/MapsView.vue')
  },
  {
    path: '/CombatRoles',
    name: 'CombatRoles',
    component: () => import('../views/CombatRoleView.vue')
  },
  {
    path: '/Operations',
    name: 'Operations',
    component: () => import('../views/OperationsView.vue'),
    props: true
  },
  {
    path: '/Operations/Details/:id',
    name: 'OperationDetails',
    component: () => import('../views/OperationsDetailView.vue'),
    props: true
  },
  {
    path: '/Operations/Create',
    name: 'OperationsCreate',
    component: () => import('../views/OperationsCreateView.vue'),
  },
  {
    path: '/Operations/Edit/:id',
    name: 'OperationEdit',
    component: () => import('../views/OperationsEditView.vue'),
    props: true
  },
  {
    path: '/Operations/Delete/:id',
    name: 'OperationDelete',
    component: () => import('../views/OperationsDeleteView.vue'),
    props: true
  },
  {
    path: '/kanyerest',
    name: 'KanyeRest',
    component: () => import('../views/KanyeRestView')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
