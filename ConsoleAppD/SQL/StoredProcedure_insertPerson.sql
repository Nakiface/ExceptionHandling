--insertPerson
CREATE PROCEDURE insertPerson
(
	@p_nr	INT,
	@vname	VARCHAR(255),
	@nname	VARCHAR(255)
)
AS 
INSERT INTO T_Person
(p_nr, vname, nname)
VALUES 
(@p_nr, @vname, @nname)