USE [FlashcardsDB]
GO

-- Insertar materias
INSERT INTO Materias (Nombre)
VALUES 
('Matemáticas'),
('Ciencias'),
('Historia'),
('Inglés'),
('Programación'),
('Tecnología'),
('Arte'),
('Educación Física'),
('Economía'),
('Literatura');

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

-- Temas para Tecnología (más de 5 temas)
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
('Técnicas de pintura', 7),
('Arte contemporáneo', 7);

-- Temas para Educación Física
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Reglas del fútbol', 8),
('Calentamiento y estiramiento', 8),
('Hábitos saludables', 8);

-- Temas para Economía
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Microeconomía', 9),
('Macroeconomía', 9),
('Inflación y precios', 9);

-- Temas para Literatura
INSERT INTO Temas (Nombre, MateriaId)
VALUES 
('Literatura clásica', 10),
('Poesía moderna', 10),
('Análisis de novelas', 10);

