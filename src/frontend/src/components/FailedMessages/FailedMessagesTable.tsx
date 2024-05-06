import React, { useEffect } from 'react'
import { getFailedMessagesListAsync } from '../../dataProvider'

const FailedMessagesTable: React.FC = () => {
  useEffect(() => {
    getFailedMessagesListAsync({ pageNumber: 1, pageSize: 20 }).then(r =>
      console.log(r)
    )
  }, [])
  return <div>FailedMessagesTable</div>
}

export default FailedMessagesTable
