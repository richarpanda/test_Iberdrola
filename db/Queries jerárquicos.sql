---- GENERACION DE SP
CREATE PROCEDURE ObtenerJerarquiaDeEmpleados
    @EmployeeId INT
AS
BEGIN
    CREATE TABLE #EmployeeHierarchy (
        employee_id INT,
        first_name VARCHAR(50),
        manager_id INT
    );

    DECLARE @CurrentManagerId INT;

    WHILE @EmployeeId IS NOT NULL
    BEGIN
        INSERT INTO #EmployeeHierarchy (employee_id, first_name, manager_id)
        SELECT 
            employee_id,
            first_name,
            manager_id
        FROM 
            Employees
        WHERE 
            employee_id = @EmployeeId;

        SELECT @CurrentManagerId = manager_id
        FROM Employees
        WHERE employee_id = @EmployeeId;

        SET @EmployeeId = @CurrentManagerId;
    END

    SELECT * FROM #EmployeeHierarchy;

    -- Eliminar la tabla temporal
    DROP TABLE #EmployeeHierarchy;
END;


-------- EJCUCION DE SP
DECLARE	@return_value int

EXEC	@return_value = [dbo].[ObtenerJerarquiaDeEmpleados]
		@EmployeeId = 10

SELECT	'Return Value' = @return_value

GO
