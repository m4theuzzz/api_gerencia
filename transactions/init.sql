CREATE DATABASE base WITH OWNER postgres ALLOW_CONNECTIONS=true;

\c base;

CREATE SEQUENCE patients_id_seq START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1;

CREATE TABLE IF NOT EXISTS patients (
    id int NOT NULL DEFAULT nextval('patients_id_seq'::regclass),
    Nome varchar(128),
    Sobrenome varchar(128),
    Sexo Char,
    Nascimento Date,
    Idade int DEFAULT 0,
    Altura float,
    Peso float,
    CPF varchar(128),
    IMC float DEFAULT 0,
    createdAt TIMESTAMP not null default NOW(),
    updatedAt TIMESTAMP not null default NOW(),
    PRIMARY KEY (id)
);
CREATE INDEX idx_patients_id ON patients(id);
