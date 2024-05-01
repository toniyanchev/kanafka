import React from 'react'
import './App.css'
import { ThemeProvider } from '@mui/material'
import themes from './theme'

function App() {
  return (
    <ThemeProvider theme={themes.lightTheme}>
      <div className='App'>Hellow</div>
    </ThemeProvider>
  )
}

export default App
