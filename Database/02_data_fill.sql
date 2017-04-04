
INSERT INTO uloga(Naziv) VALUES ("administrator");
INSERT INTO mjesto(Postanski_Broj,Naziv) VALUES ("78220","Kotor Varoš");
INSERT INTO korisnik(Ime,Prezime,Korisnicko_Ime,Lozinka,Id_Uloga,Postanski_Broj,Email) 
VALUES ("Admin", "Admin", "Admin","RUWAnNHd9y37IPgxfEsPka9GQOUHdbi7LTV73D/zzD9+ykS6",1,"78220","info@mojafirma.ba");
INSERT INTO pakovanje(Naziv) VALUES("Tvrdo");
INSERT INTO jedinica_mjere(Naziv) VALUES ("kg");
INSERT INTO jedinica_mjere(Naziv) VALUES ("m");

INSERT INTO proizvodjac_robe(Naziv,Postanski_Broj) VALUES ("Firma1",78220);
INSERT INTO proizvodjac_robe(Naziv,Postanski_Broj) VALUES ("Firma2",78220);
INSERT INTO proizvodjac_robe(Naziv,Postanski_Broj) VALUES ("Firma3",78220);