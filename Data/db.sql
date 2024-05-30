CREATE TABLE Especialidades (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(125) NOT NULL,
    Descripcion TEXT NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL 
);

INSERT INTO Especialidades (Nombre, Descripcion, Estado)
VALUES ("Psiquiatría", "Estudio de los trastornos mentales​ de origen genético o neurológico", "Activo");

CREATE TABLE Medicos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NombreCompleto VARCHAR(125) NOT NULL,
    EspecialidadId INT,
    FOREIGN KEY (EspecialidadId) REFERENCES Especialidades(Id),
    Correo VARCHAR(125) NOT NULL UNIQUE,
    Telefono VARCHAR(75) NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL
);

DROP TABLE Medicos;

INSERT INTO Medicos (NombreCompleto, EspecialidadId, Correo, Telefono, Estado)
VALUES ("Juanky", 1, "Juancamiloh960@gmail.com", 3177777777, "Activo");