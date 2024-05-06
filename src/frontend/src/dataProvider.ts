import axios, { AxiosError } from 'axios'
import {
  FailedMessagesGetListParams,
  FailedMessageShortDto,
  PagedResult
} from './types'

const instance = axios.create({
  baseURL: process.env.REACT_APP_KANAFKA_ADMIN_API,
  timeout: 30000,
  headers: {
    'Access-Control-Allow-Origin': '*',
    Accept: 'application/json',
    'Content-Type': 'application/json'
  }
})

export const getFailedMessagesListAsync = (
  params: FailedMessagesGetListParams
): Promise<PagedResult<FailedMessageShortDto> | AxiosError> =>
  instance
    .get<PagedResult<FailedMessageShortDto>>('/failedMessages/getList', {
      params
    })
    .then(res => res.data)
    .catch(err => err as AxiosError)
