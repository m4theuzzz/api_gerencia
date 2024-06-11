CREATE DATABASE Base WITH OWNER postgres ALLOW_CONNECTIONS=true;

CREATE TABLE IF NOT EXISTS Patients (
    id int NOT NULL DEFAULT nextval('idx_patients_id'),
    Nome varchar(128),
    Sobrenome varchar(128),
    Sexo Char,
    Nascimento DateTime,
    Idade int,
    Altura float,
    Peso float,
    CPF varchar(128),
    IMC float,
    createdAt TIMESTAMP not null default NOW(),
    updatedAt TIMESTAMP not null default NOW(),
    PRIMARY KEY (id)
);
CREATE INDEX idx_patients_id ON Companies(id);
