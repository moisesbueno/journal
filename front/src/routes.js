// import App from 'App.vue';

import Detalhes from './components/Detalhes.vue'
import Home from './components/Home.vue';

export const routes = [
  {
    path: '',
    component: Home,
    titulo: 'home',
    name: 'home',
  },
  {
    path: '/detalhes/:id',
    component: Detalhes,
    titulo: 'detalhes',
    name: 'detalhes',
  },
]
