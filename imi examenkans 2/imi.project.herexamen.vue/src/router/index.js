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
    path: '/Maps/Create',
    name: 'MapsCreate',
    component: () => import('../views/MapsCreateView.vue')
  },
  {
    path: '/Maps/Delete/:id',
    name: 'MapDelete',
    component: () => import('../views/MapsDeleteView.vue'),
    props: true
  },
  {
    path: '/CombatRoles',
    name: 'CombatRoles',
    component: () => import('../views/CombatRolesView.vue')
  },
  {
    path: '/CombatRoles/Details/:id',
    name: 'CombatRoleDetails',
    component: () => import('../views/CombatRolesDetailView.vue'),
    props: true
  },
/*{
    path: '/CombatRoles/Create',
    name: 'CombatRolesCreate',
    component: () => import('../views/CombatRolesCreateView.vue'),
  },
  {
    path: '/CombatRoles/Edit/:id',
    name: 'CombatRoleEdit',
    component: () => import('../views/CombatRolesEditView.vue'),
    props: true
  },
  {
    path: '/CombatRoles/Delete/:id',
    name: 'CombatRoleDelete',
    component: () => import('../views/CombatRolesDeleteView.vue'),
    props: true
  },*/
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
