--deletePerson
CREATE PROCEDURE deletePerson
(
	@p_nr	INT
)
AS 
DELETE FROM T_Person
WHERE p_nr = @p_nr;