export interface FailedMessageShortDto {
  id: string
  failedOn: Date
  topic: string
  messageId: string
  retries: number
}

export interface FailedMessageDto extends FailedMessageShortDto {
  messageBody: string
  messageHeaders: string | null
  ExceptionType: string | null
  ExceptionMessage: string | null
  ExceptionStackTrace: string | null
  InnerExceptionType: string | null
  InnerExceptionMessage: string | null
  ArchivedOn: Date | null
}

export type FailedMessagesGetListParams = {
  pageNumber: number
  pageSize: number
}

export type PagedResult<TResult> = {
  results: TResult[]
  currentPage: number
  pageCount: number
  pageSize: number
  rowCount: number
}
