---- GENERACION DE SP
CREATE PROCEDURE ContadorDeCaracteres
    @InputText NVARCHAR(MAX)
AS
BEGIN
    CREATE TABLE #LetterCount (
        letter CHAR(1),
        CountLetters INT
    );

    DECLARE @CurrentLetter CHAR(1);
    DECLARE @CurrentIndex INT = 1;
    DECLARE @TextLength INT = LEN(@InputText);

    WHILE @CurrentIndex <= @TextLength
    BEGIN
        SET @CurrentLetter = SUBSTRING(@InputText, @CurrentIndex, 1);

        IF @CurrentLetter LIKE '[a-zA-Z]'
        BEGIN
            IF EXISTS (SELECT 1 FROM #LetterCount WHERE letter = @CurrentLetter)
            BEGIN
                UPDATE #LetterCount
                SET CountLetters = CountLetters + 1
                WHERE letter = @CurrentLetter;
            END
            ELSE
            BEGIN
                INSERT INTO #LetterCount (letter, CountLetters)
                VALUES (@CurrentLetter, 1);
            END
        END

        SET @CurrentIndex = @CurrentIndex + 1;
    END

    SELECT letter, CountLetters
    FROM #LetterCount
    ORDER BY letter;

    DROP TABLE #LetterCount;
END;


-------- EJECUCION DE SP
DECLARE	@return_value int

EXEC	@return_value = [dbo].[ContadorDeCaracteres]
		@InputText = N'hello world'

SELECT	'Return Value' = @return_value

GO
