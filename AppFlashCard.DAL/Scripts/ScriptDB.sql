-- Crear la base de datos
CREATE DATABASE FlashcardsDB;
GO
USE FlashcardsDB;
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
	FechaNacimiento DATE NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Clave NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    CarnetEstudiante NVARCHAR(20) NULL
);
GO

-- Tabla de Materias
CREATE TABLE Materias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Tabla de Temas
CREATE TABLE Temas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    MateriaId INT NOT NULL,
    FOREIGN KEY (MateriaId) REFERENCES Materias(Id)
);
GO

-- Tabla de Flashcards
CREATE TABLE Flashcards (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    TemaId INT NOT NULL,
    Pregunta NVARCHAR(255) NOT NULL,
    Respuesta NVARCHAR(255) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (TemaId) REFERENCES Temas(Id)
);
GO
