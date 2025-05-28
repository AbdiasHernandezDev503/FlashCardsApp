USE [FlashcardsDB]
GO

-- Insertar materias
INSERT INTO Materias (Nombre)
VALUES 
('Matem�ticas'),
('Ciencias'),
('Historia'),
('Ingl�s'),
('Programaci�n'),
('Tecnolog�a'),
('Arte'),
('Educaci�n F�sica'),
('Econom�a'),
('Literatura');

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

-- Temas para Tecnolog�a (m�s de 5 temas)
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Redes de computadoras', 6),
('Ciberseguridad', 6),
('Desarrollo Web', 6),
('Inteligencia Artificial', 6),
('Hardware y Software', 6),
('Bases de Datos', 6),
('Sistemas Operativos', 6);

-- Temas para Arte
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Historia del arte', 7),
('T�cnicas de pintura', 7),
('Arte contempor�neo', 7);

-- Temas para Educaci�n F�sica
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Reglas del f�tbol', 8),
('Calentamiento y estiramiento', 8),
('H�bitos saludables', 8);

-- Temas para Econom�a
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Microeconom�a', 9),
('Macroeconom�a', 9),
('Inflaci�n y precios', 9);

-- Temas para Literatura
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Literatura cl�sica', 10),
('Poes�a moderna', 10),
('An�lisis de novelas', 10);

