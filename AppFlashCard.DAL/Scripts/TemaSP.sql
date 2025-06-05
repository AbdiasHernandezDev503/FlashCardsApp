USE FlashcardsDB;
GO

CREATE PROCEDURE usp_InsertarEditarTema
    @IdTema    INT,            -- 0 para insertar; >0 para actualizar
    @Nombre    NVARCHAR(100),
    @MateriaId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@IdTema = 0)
    BEGIN
        INSERT INTO Temas (Nombre, MateriaId)
        VALUES (@Nombre, @MateriaId);

        -- Devuelve el Id recién creado
        SELECT SCOPE_IDENTITY() AS NuevoId;
    END
    ELSE
    BEGIN
        UPDATE Temas
           SET Nombre    = @Nombre,
               MateriaId = @MateriaId
         WHERE Id = @IdTema;

        -- Devuelve el mismo Id editado
        SELECT @IdTema AS NuevoId;
    END
END
GO

SELECT @@VERSION;