USE [FlashcardsDB]
GO

-- Insertar materias
INSERT INTO Materias (Nombre)
VALUES 
('Matem�ticas'),
('Ciencias'),
('Historia'),
('Ingl�s'),
('Programaci�n');

-- Obtener los IDs reci�n insertados (usando variables si fuera necesario)
-- O asume que los IDs se asignan del 1 al 5 seg�n el orden

-- Temas para Matem�ticas (ID = 1)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('�lgebra', 1),
('Geometr�a', 1);

-- Temas para Ciencias (ID = 2)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('F�sica b�sica', 2),
('Biolog�a celular', 2);

-- Temas para Historia (ID = 3)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Historia Antigua', 3),
('Edad Moderna', 3);

-- Temas para Ingl�s (ID = 4)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Vocabulario b�sico', 4),
('Tiempos verbales', 4);

-- Temas para Programaci�n (ID = 5)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Estructuras de control', 5),
('POO en C#', 5);

