DROP SCHEMA IF EXISTS mysoft_db;
CREATE SCHEMA mysoft_db;
USE mysoft_db;
set global optimizer_switch='derived_merge=off';
CREATE TABLE KORISNIK
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Ime                   VARCHAR(20) NOT NULL,
	Prezime               VARCHAR(20) NOT NULL,
	Sifra                 VARCHAR(4) NOT NULL,
	Id_Uloga              INTEGER NOT NULL
)
;






CREATE TABLE ULOGA
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(20) NULL
)
;





ALTER TABLE KORISNIK
	ADD FOREIGN KEY R_2 (Id_Uloga) REFERENCES ULOGA(Id)
;
