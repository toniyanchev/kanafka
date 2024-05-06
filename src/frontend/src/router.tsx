import { createBrowserRouter } from 'react-router-dom'
import FailedMessages from './containers/FailedMessages'
import NotFound from './containers/NotFound'
import ApplicationBarWrapper from './containers/ApplicationBar'

const router = createBrowserRouter(
  [
    {
      path: '/',
      element: <ApplicationBarWrapper />,
      children: [
        {
          path: '/',
          element: <div>Home</div>
        },
        {
          path: 'failed-messages',
          element: <FailedMessages />
        },
        {
          path: '*',
          element: <NotFound />
        }
      ]
    }
  ],
  { basename: `/${process.env.REACT_APP_BASENAME ?? ''}` }
)

export default router
