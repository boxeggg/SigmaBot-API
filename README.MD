# SigmaBotAPI

SigmaBotAPI is a RESTful API for managing the request queue and status of a music bot.

## Table of Contents
- [Endpoints](#endpoints)
  - [RequestController](#requestcontroller)
    - [GetAllRequests](#getallrequests)
    - [GetLastRequest](#getlastrequest)
    - [DeleteLastRequest](#deletelastrequest)
    - [ClearRequests](#clearrequests)
    - [GetRequestCount](#getrequestcount)
    - [AddRequest](#addrequest)
    - [AddPlaylist](#addplaylist)
  - [StatusController](#statuscontroller)
    - [GetStatus](#getstatus)
    - [UpdateStatus](#updatestatus)
    - [ResetStatus](#resetstatus)
- [Models](#models)
  - [RequestModel](#requestmodel)
  - [StatusModel](#statusmodel)
  - [LoopModes](#loopmodes)

## Endpoints

### RequestController

#### GetAllRequests
- **Endpoint:** `GET /api/request`
- **Description:** Retrieves all requests.
- **Response:** 200 OK with a list of requests.

#### GetLastRequest
- **Endpoint:** `GET /api/request/last`
- **Description:** Retrieves the last request in the queue.
- **Response:**
  - 200 OK with the last request.
  - 400 Bad Request if there are no requests in the queue.

#### DeleteLastRequest
- **Endpoint:** `DELETE /api/request/last`
- **Description:** Deletes the last request in the queue.
- **Response:**
  - 204 No Content if successful.
  - 400 Bad Request if deletion fails.

#### ClearRequests
- **Endpoint:** `DELETE /api/request/clear`
- **Description:** Clears all requests in the queue.
- **Response:**
  - 204 No Content if successful.
  - 400 Bad Request if clearing the queue fails.

#### GetRequestCount
- **Endpoint:** `GET /api/request/count`
- **Description:** Retrieves the count of requests in the queue.
- **Response:** 200 OK with the number of requests.

#### AddRequest
- **Endpoint:** `POST /api/request/new`
- **Description:** Adds a new request to the queue.
- **Request Body:**
  ```json
  {
    "name": "string",
    "url": "string",
    "user": "string",
    "thumbnail_Url": "string",
    "dateTime": "2024-01-01T00:00:00"
  }