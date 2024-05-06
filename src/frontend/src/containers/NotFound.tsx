import { Typography } from '@mui/material'
import SentimentVeryDissatisfiedIcon from '@mui/icons-material/SentimentVeryDissatisfied'
import React from 'react'

const NotFound: React.FC = () => {
  return (
    <div
      style={{
        position: 'fixed',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)'
      }}
    >
      <Typography variant='h3'>Page 404</Typography>
      <SentimentVeryDissatisfiedIcon sx={{ fontSize: '10vh' }} />
    </div>
  )
}

export default NotFound
