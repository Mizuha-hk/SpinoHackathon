# SNSアプリ要件定義

## ユースケース

### ユーザー関連

- ユーザーの作成，更新(公開情報)

- ユーザー情報の取得

- ユーザー検索(保留)

- ユーザーフォロー(通知あり)

### 投稿関連

- 投稿の作成，変更

- いいね，ブースト(通知あり)

- リプライの作成，変更(通知あり)

- フォローユーザーの最近の投稿取得(タイムライン)

- 特定ユーザーの投稿をn件取得(プロフィールからの取得)

- 人気投稿をn件取得

- いいねしたユーザーのn件取得

- ブーストしたユーザーのn件取得

- リプライのn件取得

- タイムラインのリアルタイム更新

- 投稿検索(保留)

### 通知関連

- 通知の取得(リアルタイム)

- 時系列順に通知の取得n件取得

## アーキテクチャ

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

## 各分野詳細
[フロントエンド要件定義](./frontend/README.md)

[バックエンド要件定義](./backend/README.md)