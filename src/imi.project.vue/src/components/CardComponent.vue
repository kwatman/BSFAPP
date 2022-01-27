<template>
    <div class="bg-white p-8 rounded-lg shadow-2xl">
        <img v-bind:src="'../src/data/Images/' + product.ImageURI" class="rounded-t-lg h-120 w-full object-cover"/>
        <div class="p-8">
            <div class="flex justify-between">
            <h2 class="text-xl font-extrabold mb-5">
                {{product.Name}}
            </h2>
            <h2 class="text-xl font-extrabold mb-5">
                € {{product.Price}}
            </h2>
            </div>
            <p>{{product.ShortDescription}}</p>
            <button class="bg-pink-400 text-pink-100 rounded-lg py-2 px-4 mt-5">
                <span>
                    <i class="fas fa-shopping-cart"></i>
                </span>
                Add to cart
            </button>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'CardComponent',
        props: ['product']
    };
</script>
