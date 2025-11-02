-- ================================================
-- CREACIÓN DE BASE DE DATOS Y TABLAS FORMULA 1
-- ================================================

-- Crear la base de datos
CREATE DATABASE Formula1;
GO

-- Usar la base de datos recién creada
USE Formula1;
GO

-- ================================================
-- TABLA: Escuderia
-- ================================================
CREATE TABLE Escuderia (
    IdEscuderia INT IDENTITY(1,1) PRIMARY KEY,
    NombreEscuderia NVARCHAR(50) NOT NULL
);
GO

-- ================================================
-- TABLA: Piloto
-- ================================================
CREATE TABLE Piloto (
    IdPiloto INT IDENTITY(1,1) PRIMARY KEY,
    NombrePiloto NVARCHAR(50) NOT NULL,
    IdEscuderia INT NOT NULL,
    Eliminado BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Piloto_Escuderia FOREIGN KEY (IdEscuderia)
        REFERENCES Escuderia(IdEscuderia)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- ================================================
-- DATOS DE EJEMPLO (opcional)
-- ================================================

-- Insertar algunas escuderías
INSERT INTO Escuderia (NombreEscuderia)
VALUES ('Mercedes'), ('Red Bull'), ('Ferrari');

-- Insertar pilotos
INSERT INTO Piloto (NombrePiloto, IdEscuderia)
VALUES ('Lewis Hamilton', 1),
       ('George Russell', 1),
       ('Max Verstappen', 2),
       ('Sergio Pérez', 2),
       ('Charles Leclerc', 3),
       ('Carlos Sainz', 3);
GO

-- ================================================
-- CONSULTA DE PRUEBA
-- ================================================

-- Mostrar pilotos con su escudería
SELECT 
    p.IdPiloto,
    p.NombrePiloto,
    e.NombreEscuderia,
    p.Eliminado
FROM Piloto p
INNER JOIN Escuderia e ON p.IdEscuderia = e.IdEscuderia;
GO
