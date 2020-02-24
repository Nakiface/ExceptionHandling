--Tabelle erzeugen
CREATE TABLE T_Person
(
	p_nr				INT					NOT NULL, 
	vname				VARCHAR (255)		NOT NULL,
	nname				VARCHAR (255)		NOT NULL,	
	CONSTRAINT PK_Person PRIMARY KEY (p_nr)
);
--Daten einfuegen
INSERT INTO T_Person (p_nr, vname, nname)
	VALUES (1, 'Willi', 'Waltner'); 
INSERT INTO T_Person (p_nr, vname, nname)
	VALUES (2, 'Klaus', 'Kleber');
INSERT INTO T_Person (p_nr, vname, nname)
	VALUES (3, 'Eddie', 'Edison');
INSERT INTO T_Person (p_nr, vname, nname)
	VALUES (4, 'Frank', 'Fabian');