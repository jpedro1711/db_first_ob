CREATE DATABASE BibliotecaDB;
GO;

USE BibliotecaDB;
GO;

CREATE TABLE GeneroLivro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL
);


CREATE TABLE Livro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(255) NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
    Status INT NOT NULL,
    NotaAvaliacao FLOAT NOT NULL,
    SomaTotalAvaliacoes INT NULL,
    TotalAvaliacoes INT NULL,
    GeneroLivroId INT NOT NULL,
    FOREIGN KEY (GeneroLivroId) REFERENCES GeneroLivro(Id)
);

CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Senha NVARCHAR(255) NOT NULL,
    TipoUsuario INT NOT NULL
);


CREATE TABLE Reserva (
    Id INT PRIMARY KEY IDENTITY(1,1),
    StatusReserva INT NOT NULL,
    DataReserva DATETIME NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);

CREATE TABLE Emprestimo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReservaId INT NOT NULL,
    DataDevolucao DATETIME NOT NULL,
    StatusEmprestimo INT NOT NULL,
    FOREIGN KEY (ReservaId) REFERENCES Reserva(Id)
);


CREATE TABLE ReservaLivro (
    ReservaId INT NOT NULL,
    LivroId INT NOT NULL,
    PRIMARY KEY (ReservaId, LivroId),
    FOREIGN KEY (ReservaId) REFERENCES Reserva(Id),
    FOREIGN KEY (LivroId) REFERENCES Livro(Id)
);
