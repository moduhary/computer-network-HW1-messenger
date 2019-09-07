/*drop table if exists users;
drop table if exists friends;
drop table if exists messages;*/

pragma foreign_keys = on;

create table if not exists users (
    user_idx integer primary key autoincrement unique,
    ID TEXT not null,
    pass text not null,
    state text not null default 'offline'
);

create table if not exists friends (
    userA integer not null,
  	userB integer not null,
    activated boolean not null default false,
    foreign key(userA) references users(user_idx) on delete cascade,
	foreign key(userB) references users(user_idx) on delete cascade,
	unique (userA, userB)
);

create table if not exists messages (
    message_idx integer primary key autoincrement,
  	sender integer not null,
  	receiver integer not null,
    message text,
    created_at timestamp default current_timestamp,
  	foreign key(sender) references users(user_idx),
    foreign key(receiver) references users(user_idx)
);