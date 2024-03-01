# Message Board API

#### By Aidan Williams

## Technologies Used

* _C#_
* _.NET_

## Description

A collection of API endpoints for a message board.

1. `GET https://localhost:5001/api/Groups`

    Returns a list of message board groups.

2. `GET https://localhost:5001/api/Messages/{group}`

    Returns a list of messages for the specified group.

    Example: `GET https://localhost:5001/api/Messages/group 1`

    This endpoint also allows the usage of the optional earlierDateTime and laterDateTime parameters to filter for messages based on the messageDateTime.

    Example: `GET https://localhost:5001/api/Messages/group 1?earlierDateTime=2/26/2024&laterDateTime=2/27/2024`

3. `GET https://localhost:5001/api/Messages/{id}`

    Returns the message specified by a messageId.

    Example: `https://localhost:5001/api/Messages/1`

4. `POST https://localhost:5001/api/Messages`

    Posts a new message. Requires a request body containing the field values for the new message.

    Example:

    `{
      "text": "string",
      "group": "string",
      "messageDateTime": "2024-03-01T00:44:55.926Z",
      "userName": "string"
    }`

5. `PUT https://localhost:5001/api/Messages/{id}/{userName}`

    Edits the message specified by an ID. userName is a required parameter and should match the userName associated with the message. Requires a request body containing the edited field values for the message.

    Example request URL: `https://localhost:5001/api/Messages/1/user 1`

    Example request body:

    `{
      "messageId": 1,
      "text": "string",
      "group": "string",
      "messageDateTime": "2024-03-01T00:49:09.913Z",
      "userName": "user 1"
    }`

6. `DELETE https://localhost:5001/api/Messages/{id}/{userName}`

    Deletes the message specified by an ID. userName is a required parameter and should match the userName associated with the message.

    Example: `DELETE https://localhost:5001/api/Messages/1/user 1`

CORS is enabled for this API, allowing users to make requests from a domain other than the one this project is running on.

## Setup Instructions

1. Clone this repo.
2. Navigate to this project's production directory.
    1. Create a file called "appsettings.json"
    2. Add the following code to the file (username and password credentials are for your local server):
    
        `{
          "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
          }
        }`
3. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory.
4. Run `dotnet ef database update` in the command line.
5. Run `dotnet run` in the command line.
6. Visit https://localhost:5001/ in your web browser.
7. Optionally, you can run `dotnet build` to compile this website without running a local server.

## Known Bugs

* _No known bugs._

## License

_[GPL](https://en.wikipedia.org/wiki/GNU_General_Public_License)_

Copyright (c) _2023_ _Aidan Williams_