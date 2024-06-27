# SigmaBotAPI

SigmaBotAPI is a RESTful API for managing the request queue and status of a [SigmaBot](https://github.com/boxeggg/SigmaBot).

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
  - `name`: string
  - `url`: string
  - `user`: string
  - `thumbnail_Url`: string
  - `dateTime`: DateTime
- **Response:**
  - 200 OK if successful.
  - 400 Bad Request if adding the request fails.

#### AddPlaylist
- **Endpoint:** `POST /api/request/playlist`
- **Description:** Adds a new playlist to the queue.
- **Request Body:** Array of `RequestModel`
- **Response:**
  - 200 OK if successful.
  - 400 Bad Request if adding the playlist fails.

### StatusController

#### GetStatus
- **Endpoint:** `GET /api/status`
- **Description:** Retrieves the current status.
- **Response:** 200 OK with the status.

#### UpdateStatus
- **Endpoint:** `PATCH /api/status`
- **Description:** Updates the current status.
- **Request Body:** JSON Patch Document for `StatusModel`
  - Example operations:
    - Replace the `guildId`: `{ "op": "replace", "path": "/guildId", "value": "newGuildId" }`
    - Replace the `loopMode`: `{ "op": "replace", "path": "/loopMode", "value": 1 }`
    - Replace the `onVoiceChannel`: `{ "op": "replace", "path": "/onVoiceChannel", "value": true }`
    - Replace the `volume`: `{ "op": "replace", "path": "/volume", "value": 75 }`
    - Replace the `skipQueued`: `{ "op": "replace", "path": "/skipQueued", "value": true }`
- **Response:**
  - 200 OK if successful.
  - 400 Bad Request if updating the status fails.

#### ResetStatus
- **Endpoint:** `PUT /api/status`
- **Description:** Resets the status to its default values.
- **Response:**
  - 200 OK if successful.
  - 400 Bad Request if resetting the status fails.

## Models

### RequestModel
- **Properties:**
  - `name`: string
  - `url`: string
  - `user`: string
  - `thumbnail_Url`: string
  - `dateTime`: DateTime

### StatusModel
- **Properties:**
  - `guildId`: string
  - `loopMode`: LoopModes
  - `onVoiceChannel`: bool
  - `volume`: double
  - `skipQueued`: bool
- **Constructor:**
  - Initializes `guildId` to an empty string.
  - Sets `loopMode` to `LoopModes.None`.
  - Sets `onVoiceChannel` to `false`.
  - Sets `volume` to `100`.
  - Sets `skipQueued` to `false`.

### LoopModes
- **Values:**
  - `None` (0)
  - `Song` (1)
  - `Queue` (2)
