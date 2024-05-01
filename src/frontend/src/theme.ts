import { createTheme } from '@mui/material/styles'
import { green, grey, red } from '@mui/material/colors'

const lightTheme = createTheme({
  palette: {
    primary: {
      main: '#556cd6'
    },
    secondary: {
      main: '#fff',
      dark: '#556cd6'
    },
    error: {
      main: red[300]
    },
    success: {
      main: green[300]
    },
    background: {
      default: '#fff'
    }
  }
})

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#dbe371'
    },
    secondary: {
      main: '#fff',
      dark: grey[900]
    },
    error: {
      main: red[300]
    },
    success: {
      main: green[300]
    },
    background: {
      default: '#000'
    }
  }
})

const themes = {
  lightTheme,
  darkTheme
}

export default themes
