-- =============================================
-- Script: Creación de tablas Universo y Superhéroe
-- Base de datos: (Puedes cambiar el nombre si deseas)
-- Autor: ChatGPT
-- Fecha: 2025-11-02
-- =============================================
 CREATE DATABASE SuperheroesDB;
 GO

 USE SuperheroesDB;
 GO

-- Verifica si las tablas ya existen y las elimina (solo para entorno de desarrollo)
IF OBJECT_ID('dbo.Superheroe', 'U') IS NOT NULL
    DROP TABLE dbo.Superheroe;

IF OBJECT_ID('dbo.Universo', 'U') IS NOT NULL
    DROP TABLE dbo.Universo;
GO

-- =============================================
-- Crear tabla Universo
-- =============================================
CREATE TABLE dbo.Universo (
    IdUniverso INT IDENTITY(1,1) PRIMARY KEY,
    NombreUniverso NVARCHAR(50) NOT NULL
);
GO

-- =============================================
-- Crear tabla Superheroe
-- =============================================
CREATE TABLE dbo.Superheroe (
    IdSuperheroe INT IDENTITY(1,1) PRIMARY KEY,
    NombreSuperheroe NVARCHAR(50) NOT NULL,
    IdUniverso INT NOT NULL,
    Eliminado BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Superheroe_Universo FOREIGN KEY (IdUniverso)
        REFERENCES dbo.Universo(IdUniverso)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);
GO

-- =============================================
-- Ejemplo de inserción de datos
-- =============================================

-- Insertar universos
INSERT INTO dbo.Universo (NombreUniverso)
VALUES ('Marvel'), ('DC Comics');

-- Insertar superhéroes
INSERT INTO dbo.Superheroe (NombreSuperheroe, IdUniverso)
VALUES ('Ironman', 1),
       ('Spiderman', 1),
       ('Batman', 2),
       ('Superman', 2);
GO

-- =============================================
-- Consulta de ejemplo
-- =============================================
SELECT 
    S.IdSuperheroe,
    S.NombreSuperheroe,
    U.NombreUniverso,
    S.Eliminado
FROM dbo.Superheroe S
INNER JOIN dbo.Universo U ON S.IdUniverso = U.IdUniverso;
GO
