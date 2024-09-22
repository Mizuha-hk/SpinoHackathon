# �o�b�N�G���h�v����`

### �F�؃T�[�r�X

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

### ���e�T�[�r�X

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

### �ʒm�T�[�r�X

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

## API��`

### �F�؃T�[�r�X

���[�U�[�o�^ `/api/identity/register` 

���[�U�[������ `/api/identity/name/{use-name}`

���O�C�� `/api/identity/login` 

���[�U�[���X�V(�@�����) `/api/identity/update` (�D��x ��)

���[�U�[�폜 `/api/identity/delete` (�D��x ��)

���[�U�[���擾(���J���) `GET:/api/users/{id}` 

���[�U�[���X�V `POST: /api/users/update` 

���[�U�[�A�C�R���A�b�v���[�h `POST: /api/users/upload-icon` 

���[�U�[�t�H���[ `POST: /api/follow` 

���[�U�[�t�H���[���� `POST: /api/unfollow`

### ���e�T�[�r�X

���e�쐬 `POST: /api/posts` 

�摜�A�b�v���[�h `POST: /api/posts/upload-asset`

���e�X�V `PUT: /api/posts/{id}` 

���e�폜 `DELETE: /api/posts/{id}`

�^�C�����C���擾 `GET: /api/posts/{index, size}` 

�g�����h���e�擾 `GET: /api/posts/trend/{index, size}` 

���胆�[�U�[�̓��e�擾 `GET: /api/posts/user/{userId, index, size}` 

### �ʒm�T�[�r�X

�ʒm�ꗗ�擾 `/api/notification/{index, size}` 

### ���A���^�C���ʐM

SignalR `/service-hub`