-- =============================================
-- CREAR BASE DE DATOS
-- =============================================
CREATE DATABASE SistemaJugadoresDB;
GO

-- Usar la base de datos recién creada
USE SistemaJugadoresDB;
GO

-- =============================================
-- CREAR TABLA EQUIPO
-- =============================================
CREATE TABLE Equipo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

-- =============================================
-- CREAR TABLA JUGADOR
-- =============================================
CREATE TABLE Jugador (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    IdEquipo INT NOT NULL,
    CONSTRAINT FK_Jugador_Equipo FOREIGN KEY (IdEquipo)
        REFERENCES Equipo(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO

-- =============================================
-- DATOS DE PRUEBA (Opcional)
-- =============================================
INSERT INTO Equipo (Nombre) VALUES ('Los Tigres'), ('Los Leones'), ('Los Dragones');

INSERT INTO Jugador (Nombre, IdEquipo) VALUES
('Carlos Pérez', 1),
('Juan López', 1),
('Luis Torres', 2),
('Pedro Ramírez', 3);
GO

-- =============================================
-- CONSULTA DE VERIFICACIÓN
-- =============================================
SELECT j.Id AS IdJugador, j.Nombre AS NombreJugador, e.Nombre AS NombreEquipo
FROM Jugador j
INNER JOIN Equipo e ON j.IdEquipo = e.Id;
GO
