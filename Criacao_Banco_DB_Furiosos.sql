-- MySQL Script generated by MySQL Workbench
-- Fri May 10 20:08:09 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema DB_FURIOSOS
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema DB_FURIOSOS
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `DB_FURIOSOS` DEFAULT CHARACTER SET utf8 ;
USE `DB_FURIOSOS` ;

-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`PESSOA`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`PESSOA` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`PESSOA` (
  `CPF` CHAR(11) NOT NULL,
  `NOME_PESSOA` VARCHAR(100) NULL,
  `DATA_NASCIMENTO` DATE NULL,
  `CNH_PESSOA` CHAR(11) NULL,
  `CEP_PESSOA` CHAR(8) NULL,
  `LOGRADOURO` VARCHAR(100) NULL,
  `NUMERO` VARCHAR(15) NULL,
  `COMPLEMENTO` VARCHAR(20) NULL,
  `BAIRRO` VARCHAR(45) NULL,
  `CIDADE` VARCHAR(45) NULL,
  `UF` CHAR(2) NULL,
  `SEXO` CHAR(1) NULL,
  PRIMARY KEY (`CPF`),
  UNIQUE INDEX `CPF_UNIQUE` (`CPF` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`CLIENTE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`CLIENTE` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`CLIENTE` (
  `PESSOA_CPF` CHAR(11) NOT NULL,
  `TIPO_CLIENTE` VARCHAR(45) NULL,
  `CNPJ_CLIENTE` CHAR(14) NULL,
  PRIMARY KEY (`PESSOA_CPF`),
  INDEX `fk_CLIENTE_PESSOA1_idx` (`PESSOA_CPF` ASC) VISIBLE,
  CONSTRAINT `fk_CLIENTE_PESSOA1`
    FOREIGN KEY (`PESSOA_CPF`)
    REFERENCES `DB_FURIOSOS`.`PESSOA` (`CPF`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`FUNCIONARIO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`FUNCIONARIO` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`FUNCIONARIO` (
  `MATRICULA` INT NOT NULL,
  `PESSOA_CPF` CHAR(11) NOT NULL,
  `CARGO` VARCHAR(45) NULL,
  PRIMARY KEY (`MATRICULA`),
  UNIQUE INDEX `MATRICULA_UNIQUE` (`MATRICULA` ASC) VISIBLE,
  INDEX `fk_FUNCIONARIO_PESSOA1_idx` (`PESSOA_CPF` ASC) VISIBLE,
  CONSTRAINT `fk_FUNCIONARIO_PESSOA1`
    FOREIGN KEY (`PESSOA_CPF`)
    REFERENCES `DB_FURIOSOS`.`PESSOA` (`CPF`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`TELEFONES`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`TELEFONES` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`TELEFONES` (
  `PESSOA_CPF1` CHAR(11) NOT NULL,
  `NUM_TELEFONE` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`PESSOA_CPF1`, `NUM_TELEFONE`),
  INDEX `fk_TELEFONES_PESSOA1_idx` (`PESSOA_CPF1` ASC) VISIBLE,
  CONSTRAINT `fk_TELEFONES_PESSOA1`
    FOREIGN KEY (`PESSOA_CPF1`)
    REFERENCES `DB_FURIOSOS`.`PESSOA` (`CPF`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`CARRO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`CARRO` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`CARRO` (
  `PLACA` VARCHAR(9) NOT NULL,
  `MODELO` VARCHAR(45) NOT NULL,
  `MARCA` VARCHAR(45) NOT NULL,
  `COR` VARCHAR(45) NULL,
  `ANO` INT NULL,
  `KM` INT NULL,
  `DISPONIBILIDADE` TINYINT NULL,
  `PRECO_KM` DECIMAL(5,2) NULL,
  `PRECO_DIARIA` DECIMAL(5,2) NULL,
  `OBSERVACOES` VARCHAR(100) NULL,
  PRIMARY KEY (`PLACA`),
  UNIQUE INDEX `PLACA_UNIQUE` (`PLACA` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`ALUGA_DEVOLVE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`ALUGA_DEVOLVE` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`ALUGA_DEVOLVE` (
  `COD_LOCACAO` INT NOT NULL,
  `CLIENTE_PESSOA_CPF` CHAR(11) NOT NULL,
  `CARRO_PLACA` VARCHAR(9) NOT NULL,
  `DATA_INICIO` DATE NULL,
  `DATA_FIM` DATE NULL,
  `VALOR_TOTAL` DECIMAL(5,2) NULL,
  `KM_INICIAL` INT NULL,
  `KM_FINAL` INT NULL,
  `INFO_LOCACAO` VARCHAR(200) NULL,
  PRIMARY KEY (`COD_LOCACAO`),
  INDEX `fk_ALUGA_DEVOLVE_CLIENTE1_idx` (`CLIENTE_PESSOA_CPF` ASC) VISIBLE,
  INDEX `fk_ALUGA_DEVOLVE_CARRO1_idx` (`CARRO_PLACA` ASC) VISIBLE,
  CONSTRAINT `fk_ALUGA_DEVOLVE_CLIENTE1`
    FOREIGN KEY (`CLIENTE_PESSOA_CPF`)
    REFERENCES `DB_FURIOSOS`.`CLIENTE` (`PESSOA_CPF`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ALUGA_DEVOLVE_CARRO1`
    FOREIGN KEY (`CARRO_PLACA`)
    REFERENCES `DB_FURIOSOS`.`CARRO` (`PLACA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`ALTERACAO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`ALTERACAO` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`ALTERACAO` (
  `COD_ALTERACAO` INT NOT NULL,
  `FUNCIONARIO_MATRICULA` INT NOT NULL,
  `CARRO_PLACA` VARCHAR(9) NOT NULL,
  `TIPO_ALTERACAO` VARCHAR(45) NULL,
  `VALOR_ANTIGO` DECIMAL(5,2) NULL,
  `VALOR_ATUAL` DECIMAL(5,2) NULL,
  PRIMARY KEY (`COD_ALTERACAO`),
  UNIQUE INDEX `COD_ALTERACAO_UNIQUE` (`COD_ALTERACAO` ASC) VISIBLE,
  INDEX `fk_ALTERACAO_CARRO1_idx` (`CARRO_PLACA` ASC) VISIBLE,
  INDEX `fk_ALTERACAO_FUNCIONARIO1_idx` (`FUNCIONARIO_MATRICULA` ASC) VISIBLE,
  CONSTRAINT `fk_ALTERACAO_CARRO1`
    FOREIGN KEY (`CARRO_PLACA`)
    REFERENCES `DB_FURIOSOS`.`CARRO` (`PLACA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ALTERACAO_FUNCIONARIO1`
    FOREIGN KEY (`FUNCIONARIO_MATRICULA`)
    REFERENCES `DB_FURIOSOS`.`FUNCIONARIO` (`MATRICULA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DB_FURIOSOS`.`USUARIO`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DB_FURIOSOS`.`USUARIO` ;

CREATE TABLE IF NOT EXISTS `DB_FURIOSOS`.`USUARIO` (
  `EMAIL` VARCHAR(20) NOT NULL,
  `SENHA` LONGTEXT NULL,
  `PESSOA_CPF` CHAR(11) NOT NULL,
  PRIMARY KEY (`EMAIL`, `PESSOA_CPF`),
  UNIQUE INDEX `EMAIL_UNIQUE` (`EMAIL` ASC) VISIBLE,
  INDEX `fk_USUARIO_PESSOA1_idx` (`PESSOA_CPF` ASC) VISIBLE,
  CONSTRAINT `fk_USUARIO_PESSOA1`
    FOREIGN KEY (`PESSOA_CPF`)
    REFERENCES `DB_FURIOSOS`.`PESSOA` (`CPF`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
