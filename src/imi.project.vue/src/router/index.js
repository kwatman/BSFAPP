import { create } from "core-js/core/object";
import { createRouter } from "vue-router";

import HomePage from '../pages/HomePage.vue';
import ProductsPage from '../pages/ProductsPage.vue';

export default createRouter({
    routes: [{
        path: '/',
        name: 'Home',
        component: HomePage,
    },
    {
        path: '/products',
        name: 'Products',
        component: ProductsPage,
    }]
});