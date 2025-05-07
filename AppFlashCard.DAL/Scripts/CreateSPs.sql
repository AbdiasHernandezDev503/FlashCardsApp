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
        RAISERROR('El nombre de usuario ya est� en uso.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Usuarios WHERE Correo = @Correo)
    BEGIN
        RAISERROR('El correo electr�nico ya est� registrado.', 16, 1);
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

