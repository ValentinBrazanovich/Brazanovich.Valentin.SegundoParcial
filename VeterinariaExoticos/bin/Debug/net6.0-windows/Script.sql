CREATE TABLE Roedores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Peso INT,
    TipoAlimentacion NVARCHAR(50),
    Longitud INT,
    EsNocturno BIT,
    LargoCola INT,
    EsAlbino BIT,
    ProfundidadExcavada INT,
    GarrasAfiladas BIT,
    TipoRoedor NVARCHAR(50)
);

-- Se insertan 3 roedores
INSERT INTO Roedores (Nombre, Peso, TipoAlimentacion, Longitud, EsNocturno, TipoRoedor)
VALUES ('Hammy', 50, 'Omnivoro', 8, 1, 'Hamster');

INSERT INTO Roedores (Nombre, Peso, TipoAlimentacion, LargoCola, EsAlbino, TipoRoedor)
VALUES ('Jamon', 30, 'Herbivoro', 6, 0, 'Raton');

INSERT INTO Roedores (Nombre, Peso, TipoAlimentacion, ProfundidadExcavada, GarrasAfiladas, TipoRoedor)
VALUES ('Topon', 80, 'Carnivoro', 12, 1, 'Topo');