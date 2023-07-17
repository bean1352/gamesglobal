import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import AuthApp from './pages/Auth.tsx'
import { BrowserRouter } from 'react-router-dom'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter>
      <AuthApp/>
    </BrowserRouter>
  </React.StrictMode>,
)
