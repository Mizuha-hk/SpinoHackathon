# バックエンド要件定義

### 認証サービス

User Event Source

```json
{
	"id":"<id>",
	"partitionKey":"<user-id>",
	"payload":
	{
		"id":"<id>",
		"partitionKey":"<user-name>",
		"email":"<email>",
		"password":"<password>",
		"createdAt":"yyyy-MM-dd-hh-mm-ss"
	},
	"eventType":"create",
	"timestamp":"yyyy-MM-dd-hh-mm-ss"
}
```

Private User Info

```json
{
	"id":"<id>",
	"partitionKey":"<user-name>",
	"email":"<email>",
	"password":"<password>",
	"createdAt":"yyyy-MM-dd-hh-mm-ss"
}
```

Public User Info

```json
{
	"id":"<id>",
	"partitionKey":"<user-name>",
	"type":"profile"
	"displayName":"<display-name>",
	"description":"<description>",
	"icon":"<icon-uri>"
}

{
	"id":"<id>",
	"partitionKey":"<userName>",
	"type":"following",
	"user": 
	{
		"userName":"<following-user-name>",
		"displayName":"<following-user-display-name>",
		"icon":"<icon-uri>"
	},
	"timestamp":"yyyy-MM-dd-hh-mm-ss"
}

{
	"id":"<id>",
	"partitionKey":"<user-name>",
	"type":"follower"
	"user": 
	{
		"userName":"<follower-user-name>",
		"displayName":"<follower-user-display-name>",
		"icon":"<icon-uri>"
	},
	"timestamp":"yyyy-MM-dd-hh-mm-ss"
}
```

### 投稿サービス

Post Event Source

```json
{
	"id": "<id>",
	"partitionKey": "<post-id>_<event-type>_<date>",
	"requestBody":
	{
		...
	},
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}
```

Post Source

```json
{
	"id": "<id>",
	"partitionKey": "<post-id>",
	"type": "post",
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"content": "<content>",
	"assets": 
	[
		"<asset-uri>",
	],
	"likes": 0,
	"comments": 0,
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}

{
	"id": "<id>",
	"partitionKey": "<post-id>",
	"type": "like",
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}

{
	"id": "<id>",
	"partitionKey": "<post-id>",
	"type": "comment",
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"content": "<content>",
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}

```

Feed Source

```json
{
	
}
```

### 通知サービス

Notification Source

```json
{
	"id": "<id>",
	"partitionKey": "<user-id>",
	"type": "like"
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"post": 
	{
		"id":"<post-id>",
		"content":"<content>"
	},
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}

{
	"id": "<id>",
	"partitionKey": "<user-id>",
	"type": "comment"
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"comment": 
	{
		"id":"<comment-id>",
		"content":"<content>"
	},
	"post": 
	{
		"id":"<post-id>",
		"content":"<content>"
	},
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}

{
	"id": "<id>",
	"partitionKey": "<user-id>",
	"type": "follow"
	"user": 
	{
		"id":"<user-id>",
		"userName":"<user-name>",
		"displayName":"<display-name>",
		"icon":"<icon-uri>"
	},
	"timestamp": "yyyy-MM-dd-hh-mm-ss"
}
```

## API定義

### 認証サービス

ユーザー登録 `/api/identity/register` 

ユーザー名検証 `/api/identity/name/{use-name}`

ログイン `/api/identity/login` 

ユーザー情報更新(機密情報) `/api/identity/update` (優先度 低)

ユーザー削除 `/api/identity/delete` (優先度 低)

ユーザー情報取得(公開情報) `GET:/api/users/{id}` 

ユーザー情報更新 `POST: /api/users/update` 

ユーザーアイコンアップロード `POST: /api/users/upload-icon` 

ユーザーフォロー `POST: /api/follow` 

ユーザーフォロー解除 `POST: /api/unfollow`

### 投稿サービス

投稿作成 `POST: /api/posts` 

画像アップロード `POST: /api/posts/upload-asset`

投稿更新 `PUT: /api/posts/{id}` 

投稿削除 `DELETE: /api/posts/{id}`

タイムライン取得 `GET: /api/posts/{index, size}` 

トレンド投稿取得 `GET: /api/posts/trend/{index, size}` 

特定ユーザーの投稿取得 `GET: /api/posts/user/{userId, index, size}` 

### 通知サービス

通知一覧取得 `/api/notification/{index, size}` 

### リアルタイム通信

SignalR `/service-hub`