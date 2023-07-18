import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import { QueryClient, QueryClientProvider } from 'react-query'
import { LoginPage } from './pages/Login.tsx'
import { RequireAuth } from './routes/RequireAuth.tsx'
import { PublicPage } from './pages/Public.tsx'
import { Layout } from './layout/Layout.tsx'
import { ProtectedPage } from './pages/Protected.tsx'
import { AuthProvider } from './context/auth.tsx'
import { RegisterPage } from './pages/Register.tsx'
import { TVShow } from './pages/TVShow.tsx'

const queryclient = new QueryClient()

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <QueryClientProvider client={queryclient}>
      <BrowserRouter>
        <AuthProvider>
          <Routes>
            <Route element={<Layout />}>
              <Route path="/" element={<Navigate to={"/login"}/>}/>
              <Route path="/login" element={<LoginPage />} />
              <Route path="/register" element={<RegisterPage />} />
              <Route
                path="/protected"
                element={
                  <RequireAuth>
                    <ProtectedPage />
                  </RequireAuth>
                }
              />
              <Route
                path="tvshow/:id"
                element={
                  <RequireAuth>
                    <TVShow />
                  </RequireAuth>
                }
              />
            </Route>
          </Routes>
        </AuthProvider>
      </BrowserRouter>
    </QueryClientProvider>
  </React.StrictMode>,
)
