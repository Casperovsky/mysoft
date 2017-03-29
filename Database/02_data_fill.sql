
INSERT INTO uloga(Naziv) VALUES ("administrator");
INSERT INTO korisnik(Ime,Prezime,Sifra,Id_Uloga,Korisnicko_Ime) VALUES ("Admin", "Admin","RUWAnNHd9y37IPgxfEsPka9GQOUHdbi7LTV73D/zzD9+ykS6",1,"admin");

SELECT korisnik.Id FROM korisnik where korisnik.Sifra = 123;
