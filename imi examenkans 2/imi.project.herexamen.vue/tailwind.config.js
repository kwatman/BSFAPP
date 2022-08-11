/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
      "./index.html",
      "./src/**/*.{vue,html,js,ts,jsx,tsx}"
  ],
  theme: {
    extend: {
        fontFamily: {
           'Exo': ['Exo', 'sans-serif']
        }
    },
  },
  plugins: [],
}
