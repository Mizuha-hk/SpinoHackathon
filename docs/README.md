# SNS�A�v���v����`

## ���[�X�P�[�X

### ���[�U�[�֘A

- ���[�U�[�̍쐬�C�X�V(���J���)

- ���[�U�[���̎擾

- ���[�U�[����(�ۗ�)

- ���[�U�[�t�H���[(�ʒm����)

### ���e�֘A

- ���e�̍쐬�C�ύX

- �����ˁC�u�[�X�g(�ʒm����)

- ���v���C�̍쐬�C�ύX(�ʒm����)

- �t�H���[���[�U�[�̍ŋ߂̓��e�擾(�^�C�����C��)

- ���胆�[�U�[�̓��e��n���擾(�v���t�B�[������̎擾)

- �l�C���e��n���擾

- �����˂������[�U�[��n���擾

- �u�[�X�g�������[�U�[��n���擾

- ���v���C��n���擾

- �^�C�����C���̃��A���^�C���X�V

- ���e����(�ۗ�)

### �ʒm�֘A

- �ʒm�̎擾(���A���^�C��)

- ���n�񏇂ɒʒm�̎擾n���擾

## �A�[�L�e�N�`��

```mermaid
graph
	client[Client App] -->|User Command| identity-server[Identity Server]
	client -->|Post Command| post-server
	client -->|Post/User Event| realtime-server[Realtime Server]
	realtime-server -->|Timeline/Notification| client
	
	realtime-server -->|Push Event| messaging-bus[Messaging Bus]
	
	messaging-bus -->|Push User Event| user-event-source
	identity-server -->|Push User Event| messaging-bus
	identity-server -->|User Query| client
	
	post-server --> |Push Post Event| messaging-bus
	post-server --> |Post Query| client
	messaging-bus -->|Save Post| post-source
	
	messaging-bus -->|Save Notification| notification-db
	messaging-bus -->|Invalidate Cache| notification-cache
	notification-server -->|Query Notification| client
	
	subgraph identity-service
		identity-server -->|Store Cache| user-cache([User Cache])
		user-cache --> |Get Cache Data| identity-server
		user-event-source[(User Event Source)] -->|Change Feed| user-view[(User View)]
		user-event-source -->|Invalidate Cache| user-cache
		user-view -->|Query Data| identity-server
	end
	
	subgraph post-service
		post-server[Post Server] -->|Store Cache| post-cache([Post Cache])
		post-cache -->|Get Cache Data| post-server
		post-source[(Post Source)] -->|Change Feed| post-view[(Post View)]
		post-source -->|Incalidate Cache| post-cache
		post-view -->|Query Data| post-server
	end
	
	subgraph notification-service
		notification-server[Notification Server] -->|Store Cache| notification-cache([Notification Cache])
		notification-cache -->|Get Cache Data| notification-server
		notification-db[(Notification DB)] -->|Query Data| notification-server
	end
```

## �e����ڍ�
[�t�����g�G���h�v����`](./frontend/README.md)

[�o�b�N�G���h�v����`](./backend/README.md)