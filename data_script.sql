BEGIN TRANSACTION;

insert into user values(null, null, 'Alex', 'Alex', 'Woodward', '00000001', '1');
insert into user values(null, null, 'Keah', 'Keah', 'Peters', '00000002', '1');
insert into user values(null, null, 'Lewis', 'Lewis', 'Alen', '00000003', '1');
insert into user values(null, null, 'Agniezka', 'Agniezka', 'Madi', '00000004', '1');
insert into user values(null, null, 'Sophie', 'Sophie', 'Higgins', '00000005', '1');
insert into user values(null, null, 'Mateusz', 'Mateusz', 'Johanik', '00000006', '1');

insert into merchant values(null, 'Museum', '00000007');
insert into merchant values(null, 'Art Gallery', '00000008');
insert into merchant values(null, 'Rock Concert', '00000009');
insert into merchant values(null, 'Comedy Standup', '00000010');
insert into merchant values(null, 'Burger Place', '00000011');
insert into merchant values(null, 'Fancy Restaurant', '00000012');

insert into location values(null, 'GoogleReference', 1.0, 1.0, 1, (SELECT id FROM merchant), 4.99);
insert into location values(null, 'GoogleReference', 1.0, 1.0, 2, (SELECT id FROM merchant), 2.99);
insert into location values(null, 'GoogleReference', 1.0, 1.0, 3, (SELECT id FROM merchant), 10.99);
insert into location values(null, 'GoogleReference', 1.0, 1.0, 4, (SELECT id FROM merchant), 11.99);

insert into subscription values(null, 1, 1);
insert into subscription values(null, 2, 2);
insert into subscription values(null, 3, 3);
insert into subscription values(null, 4, 4);

COMMIT;

