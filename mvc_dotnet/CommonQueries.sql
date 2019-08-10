
/*SOME THINGS MAY BE BROKEN TILL YOU REPLACE THE COMMENTS WITH ACTUAL DATA*/


/*=============================================================
Query for pending invites
==============================================================*/

SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = /*REPLACE WITH DESIRED ID*/ and status = 1 

/*=============================================================
Query for accepted invites
==============================================================*/

SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = /*REPLACE WITH DESIRED ID*/ and status = 2 

/*=============================================================
Query for a SINGLE accepted invite
==============================================================*/

SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = /*REPLACE WITH DESIRED ID*/ and status = 2 and reservationId = /*REPLACE WITH DESIRED ID*/

/*=============================================================
Query for a SINGLE pending invite
==============================================================*/

SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = /*REPLACE WITH DESIRED ID*/ and status = 1 and reservationId = /*REPLACE WITH DESIRED ID*/

/*=============================================================
Query to get all reservations
==============================================================*/

select * from Reservations

/*=============================================================
Query to get all users
==============================================================*/

select * from users

/*=============================================================
Query to get all pets
==============================================================*/

select * from Pets

/*=============================================================
Query to get all Users_Reservations
==============================================================*/

select * from Users_Reservations

/*=============================================================
Query to get All a SINGLE user pets
==============================================================*/

select * from Pets where userId = /*ENTER DESIRED ID HERE*/

/*=============================================================
Query to update the status to accept invite
==============================================================*/

Update Users_Reservations set status = 2 where userId = 2 and reservationId = 5

