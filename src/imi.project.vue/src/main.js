import { createApp } from 'vue';
import App from './App.vue';
import './mainstyle.css';
import router from './router';
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:5001';

createApp(App)
.use(router, axios)
.mount('#app');
