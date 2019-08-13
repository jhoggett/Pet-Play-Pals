Insert into users (username, password, salt, firstName, lastName) 
Values ('sallystevens@gmail.com', 'TKC2qLTgrTA3DfeoCODvmkWxf5c=', 'BedDp8QY3XE=', 'Sally', 'Stevens'),
('definatelyEdSheeren@gmail.com', '++bSqEhHJrYoaqF/ItmAzDrRBoo=', 'qbZ25wcBKBI=', 'Edward', 'Sheeren'),
('rickybobby@yahoo.com', 'kwBulC00cwJuIIOy3RTEbnZ0OC0=', 'iSYnlKMQFDw=', 'Ricky', 'Bobby'),
('debra@gmail.com', 'b5cHlWa9K9rU2J3V9LmEOx+m0PE=', 'ek65kqNsyCM=', 'Debra', ''),
('ClevelandIndiansFan99@gmail.com', '+v0ASw+Z6KwpRENcMBQuhIIhTkw=', 'PMIrheuD2sQ=', 'Mike', 'Morel'),
('frankthetankfella@yahoo.com', '7iEKtoSTm542m3aRO4qLDew1w0M=', 'DQrVHo+DsQc=', 'Frank', 'Fella')

Insert into Pets (userId, name, type, personality, weight, breed, age, photo)
values			 (4, 'Sammie', 'cat', 'Sassy little kitten who yells a lot', 1, 'tabby', 1, 'http://res.cloudinary.com/petplaypals/image/upload/v1565200199/Sammie_j1ek8q.png'), 
				 (4, 'Chance', 'dog', 'Spunky and playful, Terrible with cats', 50, 'Husky', 15, 'http://res.cloudinary.com/petplaypals/image/upload/v1565200230/Chance_jvatwb.jpg'),
				 (2, 'Winston', 'cat', 'A little sweetheart who is playful', 4, 'American Short-Hair', 6, 'http://res.cloudinary.com/petplaypals/image/upload/v1565198969/Winston_yqfuvl.jpg'),
				 (3, 'Hulk', 'dog', 'Spunky little monster who loves to play fetch', 6, 'Miniature Pomeranian', 1, 'http://res.cloudinary.com/petplaypals/image/upload/v1565199578/Hulk_yqb6si.jpg'),
				 (1, 'Pixie', 'dog', 'Well trained and loves other dogs', 57, 'Belgian Shepherd Dog Malinois', 3, 'http://res.cloudinary.com/petplaypals/image/upload/v1565200092/Pixie_rac3oi.jpg'),
				 (5, 'Blaze', 'dog', 'Super sweet to Humans, a jerk to other dogs', 75, 'Retriever Mix', 7, 'http://res.cloudinary.com/petplaypals/image/upload/v1565638980/uzmtcgzfarjyh38nzrzv_vlrwr0.jpg')
			
Insert into Reservations (address, startTime, endTime, petName, description)
Values ('541 E. 266th St. Euclid Ohio 44132', '160819 12:00:00 PM', '160819 2:00:00 PM', 'Sammie', 'Walk in the park'),
('30419 Clarmont Rd. Willowick Ohio 44095', '180819 09:00:00 AM', '180819 12:00:00 PM', 'Chance', 'Play in the park'),
('North Chagrin Reservation', '210819 02:00:00 PM', '210819 05:00:00 PM', 'Hulk', 'Play fetch'),
('Sim''s Park', '230819 11:30:00 AM', '230819 12:30:00 PM', 'Pixie', 'Walk in the park')

Insert into Users_Reservations (userId, reservationId, status)
Values (4, 1, 2),	
(4, 2, 2),
(3, 3, 2),
(1, 4, 2), 
(3, 1, 1),
(2, 2, 1),
(4, 3, 1),
(2, 4, 1)