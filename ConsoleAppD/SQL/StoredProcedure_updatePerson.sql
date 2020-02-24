--updatePerson
CREATE PROCEDURE updatePerson
(
	@p_nr	INT,
	@vname	VARCHAR(255),
	@nname	VARCHAR(255)
)
AS 
UPDATE T_Person SET
	vname = @vname,
	nname = @nname
WHERE p_nr = @p_nr;