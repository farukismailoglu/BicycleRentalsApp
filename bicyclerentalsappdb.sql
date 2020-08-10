create database bicyclerentalsappdb

go

use bicyclerentalsappdb

go

create table users(
	user_id int primary key identity(1, 1),
	user_name nvarchar(50) not null,
	password nvarchar(500) not null, 
	created_datetime datetime not null,
	score int 
)

go 

create table locations(
	location_id int primary key identity(1, 1),
	city nvarchar(50) not null,
	country nvarchar(50)  not null,
	latitude nvarchar(50) not null,
	longitude nvarchar(50) not null
)

go 
create table stations(
	station_id int primary key  identity(1, 1),
	location_id int foreign key references locations(location_id) ,
	name nvarchar(50) not null,
	free_bikes int not  null,
	empty_slots int not null
)

go

Alter  table stations
add constraint Chk_FreeBikes Check(free_bikes>=0) 