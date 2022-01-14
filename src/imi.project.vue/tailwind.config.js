module.exports = {
  content: [
    './index.html',
    './src/**/*.{vue,js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      colors: {
        'glazed-pink': '#F3B497',
      },
      fontFamily: {
        'montserrat': "'montserrat', sans-serif",
        'trocchi': "'trocchi', serif",
      },
      backgroundImage: {
        'landing': "url('/src/assets/Landing_Page.png')"
      },
    },

  },
  plugins: [],
};
