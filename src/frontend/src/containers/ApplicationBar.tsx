import { Menu } from '@mui/icons-material'
import {
  AppBar,
  Box,
  Button,
  Container,
  IconButton,
  Menu as MuiMenu,
  MenuItem,
  Toolbar,
  Typography,
  useTheme
} from '@mui/material'
import React from 'react'
import { Outlet, useNavigate } from 'react-router-dom'

const pages = ['Failed Messages']

const ApplicationBar: React.FC = () => {
  const navigate = useNavigate()
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null)
  const theme = useTheme()

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget)
  }

  const goToPage = (pageName: string) => {
    closeNav()
    navigate(pageName.replaceAll(' ', '-').toLowerCase())
  }

  const closeNav = () => {
    setAnchorElNav(null)
  }

  return (
    <AppBar position='fixed'>
      <Container maxWidth='xl'>
        <Toolbar disableGutters>
          <Typography
            variant='h6'
            noWrap
            component='a'
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none'
            }}
          >
            <Box
              component='img'
              src={`${process.env.PUBLIC_URL}/logo192.png`}
              sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }}
              onClick={() => goToPage('')}
              width={60}
              height={60}
            />
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <IconButton
              size='large'
              aria-label='account of current user'
              aria-controls='menu-appbar'
              aria-haspopup='true'
              onClick={handleOpenNavMenu}
              color='inherit'
            >
              <Menu />
            </IconButton>
            <MuiMenu
              id='menu-appbar'
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left'
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'left'
              }}
              open={Boolean(anchorElNav)}
              onClose={closeNav}
              sx={{
                display: { xs: 'block', md: 'none' }
              }}
            >
              {pages.map(page => (
                <MenuItem key={page} onClick={() => goToPage(page)}>
                  <Typography
                    textAlign='center'
                    sx={{ color: 'secondary', fontWeight: 'bold' }}
                  >
                    {page}
                  </Typography>
                </MenuItem>
              ))}
            </MuiMenu>
          </Box>
          <Box
            component='img'
            src={`${process.env.PUBLIC_URL}/logo192.png`}
            sx={{ display: { xs: 'flex', md: 'none' }, mt: 0.5, mb: 0.5 }}
            onClick={() => goToPage('')}
            width={60}
            height={60}
          />
          <Typography
            variant='h5'
            noWrap
            component='a'
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none'
            }}
          ></Typography>
          <Box
            sx={{ flexGrow: 1, gap: 2, display: { xs: 'none', md: 'flex' } }}
          >
            {pages.map(page => (
              <Button
                key={page}
                onClick={() => goToPage(page)}
                variant='text'
                sx={{
                  my: 2,
                  display: 'block',
                  color: theme.palette.secondary.main,
                  fontWeight: 'bold'
                }}
              >
                {page}
              </Button>
            ))}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  )
}

const ApplicationBarWrapper: React.FC = () => (
  <div>
    <ApplicationBar />
    <Outlet />
  </div>
)

export default ApplicationBarWrapper
