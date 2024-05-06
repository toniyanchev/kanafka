import React from 'react'
import './App.css'
import { ThemeProvider } from '@mui/material'
import themes from './theme'
import { RouterProvider } from 'react-router-dom'
import router from './router'

const App: React.FC = () => {
  return (
    <ThemeProvider theme={themes.lightTheme}>
      <div className='App' style={{ marginTop: 70 }}>
        <RouterProvider router={router} />
      </div>
    </ThemeProvider>
  )
}

export default App
