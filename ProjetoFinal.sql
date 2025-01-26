CREATE DATABASE IF NOT EXISTS banco_siscadastro;
USE banco_siscadastro;

CREATE TABLE `autor` (
  `idautor` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) DEFAULT NULL, 
  PRIMARY KEY (`idautor`)
);

CREATE TABLE `livros` (
  `idlivros` INT NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(45) DEFAULT NULL,
  `editora` VARCHAR(30) DEFAULT NULL,
  `edicao` INT DEFAULT NULL,
  `anoPublicacao` INT DEFAULT NULL,
  `numeroPaginas` INT DEFAULT NULL,
  `fk_idAutor` INT DEFAULT NULL,
  PRIMARY KEY (`idlivros`),
  KEY `idAutor_idx` (`fk_idAutor`),
  CONSTRAINT `fk_autor` FOREIGN KEY (`fk_idAutor`) REFERENCES `autor` (`idautor`)
);
select * from livros;