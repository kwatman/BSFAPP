import { 
    createRouter,
    createWebHashHistory,
} from "vue-router";

import HomePage from '../pages/HomePage.vue';
import ProductsPage from '../pages/ProductsPage.vue';

export default createRouter({
    history: createWebHashHistory(),
    routes: [{
        path: '/',
        name: 'Home',
        component: HomePage,
    },
    {
        path: '/products',
        name: 'Products',
        component: ProductsPage,
    }],
});