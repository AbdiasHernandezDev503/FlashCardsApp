USE FlashcardsDB;
GO

CREATE PROCEDURE usp_InsertarEditarMateria
    @IdMateria INT,            -- 0 para insertar, >0 para editar
    @Nombre    NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@IdMateria = 0)
    BEGIN
        INSERT INTO Materias (Nombre)
        VALUES (@Nombre);

        -- Devolver el Id recién creado
        SELECT SCOPE_IDENTITY() AS NuevoId;
    END
    ELSE
    BEGIN
        UPDATE Materias
           SET Nombre = @Nombre
         WHERE Id = @IdMateria;

        -- Devolver el mismo Id
        SELECT @IdMateria AS NuevoId;
    END
END
GO
