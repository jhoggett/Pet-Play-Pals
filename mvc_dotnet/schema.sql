
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='PetPlayPals')
DROP DATABASE PetPlayPals;
GO

-- Create a new DemoDB Database
CREATE DATABASE PetPlayPals;
GO

-- Switch to the DemoDB Database
USE PetPlayPals
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),
	firstName	varchar(50),
	lastName	varchar(50)

	constraint pk_users primary key (id)
);

Create Table Pets
(
	id			int			 identity(1,1),
	userId		int			 not null,
	name		varchar(50)  not null, 
	type		varchar(50)  not null, 
	personality varchar(500) not null,
	weight		int		     not null, 
	breed		varchar(500)  not null,
	age			int			 not null, 
	photo		varchar(500)  not null,

	constraint pk_Pets  primary key (id),
	constraint fk_UserId foreign key (userId) references users(Id),
);


COMMIT TRANSACTION;