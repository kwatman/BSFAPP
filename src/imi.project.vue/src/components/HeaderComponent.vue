<template>
  <header>
    <nav class="bg-stone-50">
      <div class="px-16">
        <div class="flex justify-between">
          <!-- NAVBAR LEFT -->
          <div class="flex space-x-8">
            <!-- LOGO -->
            <div>
              <img src="..\assets\Title.png" class="object-contain h-24" alt="Glazed Logo"/>
            </div>
            <!-- PAGES -->
            <div class="flex items-center space-x-14">
              <a href="#" class="text-stone-900 font-montserrat font-bold text-lg hover:text-glazed-pink">Home</a>
              <a href="#" class="text-stone-900 font-montserrat font-bold text-lg hover:text-glazed-pink">Producten</a>
              <a href="#" class="text-stone-900 font-montserrat font-bold text-lg hover:text-glazed-pink">Blog</a>
              <a href="#" class="text-stone-900 font-montserrat font-bold text-lg hover:text-glazed-pink">Contact</a>
            </div>
          </div>
          <!-- NAVBAR RIGHT -->
          <div class="flex justify-between items-center space-x-8">
            <div class="flex items-center space-x-3">
              <a href="#" class="text-stone-900 font-montserrat hover:text-glazed-pink">Log In</a>
              <p class="text-stone-900 font-montserrat font-bold">|</p>
              <a href="#" class="text-stone-900 font-montserrat hover:text-glazed-pink">Sign In</a>
            </div>
            <div>
              <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 text-stone-900 hover:text-glazed-pink" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z" />
              </svg>
            </div>
          </div>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'HeaderComponent',
};
</script>
