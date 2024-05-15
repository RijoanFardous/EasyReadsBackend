# EasyReads Backend

## User Endpoints

- **Signup**
  - POST `https://localhost:7281/api/user/signup`
  - Payload: `username, fullname, email, password`

- **Login**
  - POST `https://localhost:7281/api/user/login`
  - Payload: `username, password`

- **Logout**
  - DELETE `https://localhost:7281/api/user/logout`

- **Change Password**
  - PUT `https://localhost:7281/api/user/changepassword`
  - Payload: `username, currentpass, newpass`

- **Get All Users**
  - GET `https://localhost:7281/api/user/get/all`

- **Get User**
  - GET `https://localhost:7281/api/user/get/{username}`

- **Get Profile**
  - GET `https://localhost:7281/api/user/get/profile/{username}`

- **Update Profile**
  - PUT `https://localhost:7281/api/user/update/profile/{username}`

## Article Endpoints

- **Create Article**
  - POST `https://localhost:7281/api/article/create`
  - Payload: `title, content, writtenby, audience, topicId`

- **Delete Article**
  - DELETE `https://localhost:7281/api/article/delete/{id}`

- **Get All Public Articles**
  - GET `https://localhost:7281/api/article/get/all/public`

- **Get All Public Articles By Author**
  - GET `https://localhost:7281/api/article/get/all/{username}/public`

- **Get All Followers Articles By Author**
  - GET `https://localhost:7281/api/article/get/all/{username}/followers`

- **Get All Private Articles By Author**
  - GET `https://localhost:7281/api/article/get/all/{username}/private`

- **Get All Articles By Topic**
  - GET `https://localhost:7281/api/article/get/all/topic/{topicId}`

- **Get Article**
  - GET `https://localhost:7281/api/article/get/{id}`

- **Update Article**
  - PUT `https://localhost:7281/api/article/update/{id}`

- **Get Article Version**
  - GET `https://localhost:7281/api/article/version/get/{id}`

- **Get All Article Versions**
  - GET `https://localhost:7281/api/article/version/get/all/{articleid}`

- **Restore Article Version**
  - POST `https://localhost:7281/api/article/version/restore/{id}`

## Topic Endpoints

- **Create Topic**
  - POST `https://localhost:7281/api/topic/addtopic`
  - Payload: `topicname`

- **Get All Topics**
  - GET `https://localhost:7281/api/topic/getalltopic`

- **Get Topic**
  - GET `https://localhost:7281/api/topic/gettopic/{id}`

- **Update Topic**
  - PUT `https://localhost:7281/api/topic/updatetopic/{id}`
  - Payload: `topic object`

- **Follow Topic**
  - POST `https://localhost:7281/api/topic/followtopic/{id}`
  - Payload: `topicid, username`

- **UnFollow Topic**
  - DELETE `https://localhost:7281/api/topic/unfollowtopic/{id}`
  - Payload: `topicid, username`

## Bookmark Endpoints

- **Create Bookmark**
  - POST `https://localhost:7281/api/bookmark/create`
  - Payload: `articleid, username`

- **Get Bookmark**
  - GET `https://localhost:7281/api/bookmark/get/{id}`

- **Get User Bookmarks**
  - GET `https://localhost:7281/api/bookmark/get/user/{username}`

- **Delete Bookmark**
  - DELETE `https://localhost:7281/api/bookmark/delete/{id}`

## Comments Endpoints

- **Create Comment**
  - POST `https://localhost:7281/api/comment/create`
  - Payload: `content, articleid, username`

- **Get Comment**
  - GET `https://localhost:7281/api/comment/get/{id}`

- **Get Article Comments**
  - GET `https://localhost:7281/api/comment/allcomments/{articleid}`

- **Update Comment**
  - PUT `https://localhost:7281/api/comment/update/{id}`

- **Delete Comment**
  - DELETE `https://localhost:7281/api/comment/delete/{id}`


## Replies Endpoints

- **Create Reply**
  - POST `https://localhost:7281/api/comment/reply/create`
  - Payload: `content, commentid, username`

- **Get Reply**
  - GET `https://localhost:7281/api/comment/reply/get/{id}`

- **Get Comment Replies**
  - GET `https://localhost:7281/api/comment/get/{commentid}/reply`

- **Update Reply**
  - PUT `https://localhost:7281/api/comment/reply/update/{replyid}`

- **Delete Reply**
  - DELETE `https://localhost:7281/api/comment/reply/delete/{id}`


## Stats Endpoints

- **Stats of User**
  - GET `https://localhost:7281/api/stats/{username}`
  - Query Parameters: `username, startdate (optional), enddate (optional)`

- **Stats of Topic**
  - GET `https://localhost:7281/api/stats/topic/{topicId}`
  - Query Parameters: `topicId, startdate (optional), enddate (optional)`

- **Top Articles**
  - GET `https://localhost:7281/api/stats/top/articles`

- **Basic Stats**
  - GET `https://localhost:7281/api/stats/basic`

## Likes Endpoints

- **Create Like**
  - POST `https://localhost:7281/api/like/create`
  - Payload: `articleid, username`

- **Get Article Likes**
  - GET `https://localhost:7281/api/like/getalllikes/{articleId}`

- **Delete Like**
  - DELETE `https://localhost:7281/api/like/delete/{id}`

## Followers Endpoints

- **Create Follower**
  - POST `https://localhost:7281/api/follower/create`
  - Payload: `followerusername, followedusername`

- **Get Followers**
  - GET `https://localhost:7281/api/follower/getallfollowers/{username}`

- **Get Followings**
  - GET `https://localhost:7281/api/follower/getallfollowings/{username}`

- **Delete Follower**
  - DELETE `https://localhost:7281/api/follower/delete`
  - Payload: `followerusername, followedusername`

## Applications Endpoints

- **Create Application**
  - POST `https://localhost:7281/api/application/create`
  - Payload: `description, articleid, username`

- **Get Application**
  - GET `https://localhost:7281/api/application/get/{id}`

- **Get All Applications**
  - GET `https://localhost:7281/api/application/getall`

- **Get User Applications**
  - GET `https://localhost:7281/api/application/user/{username}`

- **Get Pending Applications**
  - GET `https://localhost:7281/api/application/getall/pending`

- **Get Rejected Applications**
  - GET `https://localhost:7281/api/application/getall/rejected`

- **Get Approved Applications**
  - GET `https://localhost:7281/api/application/getall/approved`

- **Approve Application**
  - PUT `https://localhost:7281/api/application/approve/{id}`

- **Reject Application**
  - PUT `https://localhost:7281/api/application/reject/{id}`

## Reports Endpoints

- **Create Report**
  - POST `https://localhost:7281/api/report/create`
  - Payload: `reason, articleid, username`

- **Get Report**
  - GET `https://localhost:7281/api/report/get/{id}`

- **Get All Reports**
  - GET `https://localhost:7281/api/report/getall`

- **Get User Reports**
  - GET `https://localhost:7281/api/report/user/{username}`

- **Get Pending Reports**
  - GET `https://localhost:7281/api/report/getall/pending`

- **Get Rejected Reports**
  - GET `https://localhost:7281/api/report/getall/rejected`

- **Get Approved Reports**
  - GET `https://localhost:7281/api/report/getall/approved`

- **Approve Report**
  - PUT `https://localhost:7281/api/report/approve/{id}`

- **Reject Report**
  - PUT `https://localhost:7281/api/report/reject/{id}`

## Search Endpoints

- **Search**
  - GET `https://localhost:7281/api/search/{keyword}`
  - Note: Start with '@' for users
