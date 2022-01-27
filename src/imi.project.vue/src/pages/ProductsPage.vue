<template>
    <div class="max-w-2xl mx-auto py-16 px-4 sm:py-24 sm:px-6 lg:max-w-7xl lg:px-8">
        <h2 class="sr-only">Producten</h2>
    </div>
    <CardComponent v-for="product in availableProducts" v-bind:key="product.Id" v-bind:product="product"/>
</template>

<script>
import CardComponent from '../components/CardComponent.vue';
import axios from 'axios';

export default {
  components: {
      CardComponent,
  },
    name: 'productsPage',
    data() {
        return{
            availableProducts: [],
        };
    },
    mounted(){
        this.getAllProducts()
    },
    methods: {
        getAllProducts() {
            axios.get('/api/products')
            .then(Response => {
                this.availableProducts = Response.data
            })
            .catch(error => {
                console.log(error)
            })
        }
    }
};
</script>
