USE [FlashcardsDB]
GO

-- Insertar materias
INSERT INTO Materias (Nombre)
VALUES 
('Matemáticas'),
('Ciencias'),
('Historia'),
('Inglés'),
('Programación');

-- Obtener los IDs recién insertados (usando variables si fuera necesario)
-- O asume que los IDs se asignan del 1 al 5 según el orden

-- Temas para Matemáticas (ID = 1)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Álgebra', 1),
('Geometría', 1);

-- Temas para Ciencias (ID = 2)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Física básica', 2),
('Biología celular', 2);

-- Temas para Historia (ID = 3)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Historia Antigua', 3),
('Edad Moderna', 3);

-- Temas para Inglés (ID = 4)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Vocabulario básico', 4),
('Tiempos verbales', 4);

-- Temas para Programación (ID = 5)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Estructuras de control', 5),
('POO en C#', 5);

