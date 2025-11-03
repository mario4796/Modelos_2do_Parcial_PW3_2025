-- ============================================================
-- CREACIÓN DE LA BASE DE DATOS
-- ============================================================
CREATE DATABASE ReservasViajes;
GO

USE ReservasViajes;
GO

-- ============================================================
-- TABLA: Destino
-- ============================================================
CREATE TABLE Destino (
    IdDestino INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);
GO

-- ============================================================
-- TABLA: Reserva
-- ============================================================
CREATE TABLE Reserva (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    CantidadPasajeros INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    IdDestino INT NOT NULL,
    Eliminado BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Reserva_Destino FOREIGN KEY (IdDestino)
        REFERENCES Destino(IdDestino)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- ============================================================
-- EJEMPLOS DE INSERCIÓN DE DATOS
-- ============================================================

-- Insertamos algunos destinos
INSERT INTO Destino (Nombre)
VALUES ('París'), ('Roma'), ('Tokio');

-- Insertamos algunas reservas de ejemplo
INSERT INTO Reserva (CantidadPasajeros, FechaInicio, FechaFin, IdDestino)
VALUES (5, '2025-07-01', '2025-07-10', 1),
       (2, '2025-08-15', '2025-08-25', 2);
GO

-- ============================================================
-- CONSULTA DE PRUEBA CON RELACIÓN ENTRE TABLAS
-- ============================================================
SELECT 
    R.IdReserva,
    R.CantidadPasajeros,
    R.FechaInicio,
    R.FechaFin,
    D.Nombre AS Destino,
    R.Eliminado
FROM Reserva R
INNER JOIN Destino D ON R.IdDestino = D.IdDestino;
GO
