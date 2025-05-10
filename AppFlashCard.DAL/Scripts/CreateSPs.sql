USE [FlashcardsDB]
GO

-- Procedimiento para insertar un Usuario
CREATE PROCEDURE [dbo].[SP_RegistrarUsuario]
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
	@FechaNacimiento DATE,
    @Username NVARCHAR(50),
    @Clave NVARCHAR(100),
    @Correo NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @CarnetEstudiante NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el username o correo ya existen
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Username = @Username)
    BEGIN
        RAISERROR('El nombre de usuario ya está en uso.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Usuarios WHERE Correo = @Correo)
    BEGIN
        RAISERROR('El correo electrónico ya está registrado.', 16, 1);
        RETURN;
    END

    -- Insertar nuevo usuario
    INSERT INTO Usuarios (
        Nombres, Apellidos, FechaNacimiento, Username, Clave,
        Correo, Telefono, CarnetEstudiante
    )
    VALUES (
        @Nombres, @Apellidos, @FechaNacimiento, @Username, @Clave,
        @Correo, @Telefono, @CarnetEstudiante
    );
END
GO

CREATE PROCEDURE [dbo].[SP_LoginUsuario] (
	@Username NVARCHAR(50)
) AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Nombres, Apellidos, Username, Clave
    FROM Usuarios
    WHERE Username = @Username;
END
GO

CREATE PROCEDURE [dbo].[SP_InsertarFlashcard]
    @UsuarioId INT,
    @TemaId INT,
    @Pregunta NVARCHAR(MAX),
    @Respuesta NVARCHAR(MAX)
AS
BEGIN
    -- Validar límite de creacion de flashcards a 20 por tema y usuario
    IF (SELECT COUNT(*) FROM Flashcards WHERE UsuarioId = @UsuarioId AND TemaID = @TemaId) >= 20
    BEGIN
        RAISERROR('Has alcanzado el límite de 20 flashcards para este tema.', 16, 1);
        RETURN;
    END

    INSERT INTO Flashcards (UsuarioId, TemaId, Pregunta, Respuesta, FechaCreacion)
    VALUES (@UsuarioId, @TemaId, @Pregunta, @Respuesta, GETDATE());
END

GO
CREATE FUNCTION [dbo].[FN_ContarFlashcardsPorTemaUsuario]
(
    @UsuarioId INT,
    @TemaId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Cantidad INT;

    SELECT @Cantidad = COUNT(*)
    FROM Flashcards
    WHERE UsuarioId = @UsuarioId AND TemaId = @TemaId;

    RETURN @Cantidad;
END
GO
CREATE PROCEDURE [dbo].[SP_ObtenerInfoTemaFlashcards]
AS
BEGIN
    SELECT 
        m.Nombre AS Materia,
        t.Nombre AS Tema,
        u.Username AS Usuario
    FROM Flashcards f
    INNER JOIN Temas t ON f.TemaId = t.Id
    INNER JOIN Materias m ON t.MateriaId = m.Id
    INNER JOIN Usuarios u ON f.UsuarioId = u.Id
    GROUP BY m.Nombre, t.Nombre, u.Username
    ORDER BY m.Nombre, t.Nombre;
END

GO

SELECT * FROM Flashcards;
SELECT * FROM Materias;
SELECT * FROM Usuarios;
-- Reiniciar los ids cuando sea necesario
DBCC CHECKIDENT ('Usuarios', RESEED, 0); 

