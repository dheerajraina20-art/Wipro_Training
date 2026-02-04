import './style.css'

const app = document.querySelector('#app')

function loadHome() {
  app.innerHTML = `
    <h2>🏠 Home Page</h2>
    <p>Welcome to our SPA website.</p>
  `
}

function loadProducts() {
  app.innerHTML = `
    <h2>🛍️ Products Page</h2>
    <p>Here are our awesome products.</p>
  `
}

document.addEventListener('click', (e) => {
  if (e.target.id === 'homeLink') {
    loadHome()
  }
  if (e.target.id === 'productsLink') {
    loadProducts()
  }
})

// Load home page first
loadHome()
