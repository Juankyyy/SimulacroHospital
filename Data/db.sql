CREATE TABLE Especialidades (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(125) NOT NULL,
    Descripcion TEXT NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL 
);

CREATE TABLE Medicos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NombreCompleto VARCHAR(125) NOT NULL,
    EspecialidadId INT,
    FOREIGN KEY (EspecialidadId) REFERENCES Especialidades(Id),
    Correo VARCHAR(125) NOT NULL UNIQUE,
    Telefono VARCHAR(75) NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL
);