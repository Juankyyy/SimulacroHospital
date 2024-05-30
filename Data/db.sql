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
    EspecialidadId INT NOT NULL,
    FOREIGN KEY (EspecialidadId) REFERENCES Especialidades(Id),
    Correo VARCHAR(125) NOT NULL UNIQUE,
    Telefono VARCHAR(75) NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL
);

DROP TABLE Medicos;

INSERT INTO Medicos (NombreCompleto, EspecialidadId, Correo, Telefono, Estado)
VALUES ("Juanky", 1, "Juancamiloh960@gmail.com", 3177777777, "Activo");

CREATE TABLE Pacientes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombres VARCHAR(125) NOT NULL,
    Apellidos VARCHAR(125) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Correo VARCHAR(125) NOT NULL UNIQUE,
    Telefono VARCHAR(75) NOT NULL,
    Direccion VARCHAR(125) NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL
);

INSERT INTO Pacientes (Nombres, Apellidos, FechaNacimiento, Correo, Telefono, Direccion, Estado)
VALUES ("Mateo", "V", "2002-05-05", "mateo@gmail.com", "3100000000", "Calle 1 #11-D", "Activo");

CREATE TABLE Citas (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    MedicoId INT NOT NULL,
    FOREIGN KEY (MedicoId) REFERENCES Medicos(Id),
    PacienteId INT NOT NULL,
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(Id),
    Fecha DATE NOT NULL,
    Estado ENUM("Activo", "Inactivo") NOT NULL
);

INSERT INTO Citas (MedicoId, PacienteId, Fecha, Estado)
VALUES (1, 1, "2024-05-30", "Activo")