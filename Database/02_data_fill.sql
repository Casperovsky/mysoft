
INSERT INTO uloga(Naziv) VALUES ("administrator");
INSERT INTO korisnik(Ime,Prezime,Sifra,Id_Uloga) VALUES ("Admin", "Admin","1234",1);

SELECT korisnik.Id FROM korisnik where korisnik.Sifra = 123;
