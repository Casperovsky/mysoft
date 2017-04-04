DROP SCHEMA IF EXISTS mysoft_db;
CREATE SCHEMA mysoft_db;
USE mysoft_db;
set global optimizer_switch='derived_merge=off';

CREATE TABLE JEDINICA_MJERE
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL
)
;




CREATE TABLE KORISNIK
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Ime                   VARCHAR(255) NOT NULL,
	Prezime               VARCHAR(255) NOT NULL,
	Korisnicko_Ime        VARCHAR(255) NOT NULL,
	Lozinka               VARCHAR(255) NOT NULL,
	Id_Uloga              INTEGER NOT NULL,
	Postanski_Broj        INTEGER NOT NULL,
	Email                 VARCHAR(255) NOT NULL
)
;






CREATE TABLE MJESTO
(
	Postanski_Broj        INTEGER PRIMARY KEY,
	Naziv                 VARCHAR(255) NOT NULL
)
;




CREATE TABLE PAKOVANJE
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL
)
;






CREATE TABLE POREZ
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL
)
;





CREATE TABLE PROIZVODJAC_ROBE
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL,
	Postanski_Broj        INTEGER NOT NULL
)
;





CREATE TABLE ROBA
(
	Sifra                 INTEGER PRIMARY KEY,
	BarKod                INTEGER NOT NULL,
	Status                VARCHAR(255) NOT NULL,
	Naziv                 VARCHAR(255) NOT NULL,
	Oznaka                VARCHAR(255) NULL,
	Oznaka2               VARCHAR(255) NULL,
	Id_Proizvodjac        INTEGER  NULL,
	Id_Pakovanje          INTEGER  NULL,
	Id_Tip_Robe           INTEGER  NULL,
	Id_Porez              INTEGER  NULL,
	Id_Jedinica_Mjere     INTEGER  NULL
)
;





CREATE TABLE TIP_ROBE
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL
)
;





CREATE TABLE ULOGA
(
	Id                    INTEGER PRIMARY KEY AUTO_INCREMENT,
	Naziv                 VARCHAR(255) NOT NULL
)
;





ALTER TABLE KORISNIK
	ADD FOREIGN KEY R_1 (Id_Uloga) REFERENCES ULOGA(Id)
;


ALTER TABLE KORISNIK
	ADD FOREIGN KEY R_2 (Postanski_Broj) REFERENCES MJESTO(Postanski_Broj)
;



ALTER TABLE PROIZVODJAC_ROBE
	ADD FOREIGN KEY R_3 (Postanski_Broj) REFERENCES MJESTO(Postanski_Broj)
;



ALTER TABLE ROBA
	ADD FOREIGN KEY R_4 (Id_Proizvodjac) REFERENCES PROIZVODJAC_ROBE(Id)
;


ALTER TABLE ROBA
	ADD FOREIGN KEY R_5 (Id_Pakovanje) REFERENCES PAKOVANJE(Id)
;


ALTER TABLE ROBA
	ADD FOREIGN KEY R_6 (Id_Tip_Robe) REFERENCES TIP_ROBE(Id)
;


ALTER TABLE ROBA
	ADD FOREIGN KEY R_7 (Id_Porez) REFERENCES POREZ(Id)
;


ALTER TABLE ROBA
	ADD FOREIGN KEY R_8 (Id_Jedinica_Mjere) REFERENCES JEDINICA_MJERE(Id)
;