BEGIN TRANSACTION;

insert into user values(null, null, 'Alex', 'Alex', 'Woodward', '00000001', '1');

insert into merchant values(null, 'Test merchant', '00000007');

insert into location values(null, 'GoogleReference', 1.0, 1.0, 1, (SELECT id FROM merchant), 4.99);

insert into subscription values(null, (SELECT id FROM user), (select id FROM merchant));

COMMIT;