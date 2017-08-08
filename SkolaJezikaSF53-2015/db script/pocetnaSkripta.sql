/*create database SkolaJezikaSF53_2015*/
use SkolaJezikaSF53_2015

create table korisnici(
id bigint identity primary key,
obrisan bit,
ime varchar(30),
prezime varchar(30),
jmbg varchar(13) unique not null,
usn varchar(25) unique not null,
psw varchar(30) not null,
isAdmin bit
)

create table skola(
id bigint identity primary key,
naziv varchar(30),
adresa varchar(50),
telefon varchar(20) unique not null,
email varchar(25) not null,
website varchar(25) not null,
pib varchar(20) not null,
maticniBroj varchar(20) not null,
ziroRacun varchar(25) not null,
)

create table nastavnici(
	id bigint identity primary key not null,
	obrisan bit,
	ime varchar(30) not null,
	prezime varchar(30) not null,
	jmbg varchar(13) unique not null,
	plata float(6) not null
	)


create table kursevi(
	id bigint identity primary key not null,
	obrisan bit,
	jezik varchar(30),
	tip varchar(10),
	cena float(6) not null,
	nastavnik_id bigint foreign key references nastavnici(id),
);

create table ucenici(
	id bigint identity primary key not null,
	obrisan bit,
	ime varchar(30) not null,
	prezime varchar(30) not null,
	jmbg varchar(13) unique not null,
);


create table predaje(
	nastavnik_id bigint foreign key references nastavnici(id) not null,
	kurs_id bigint foreign key references kursevi(id) not null,
	primary key (nastavnik_id, kurs_id)

);

create table pohadja(
	ucenik_id bigint foreign key references ucenici(id) not null,
	kurs_id bigint foreign key references kursevi(id) not null,
	primary key (ucenik_id, kurs_id)
);


create table uplate(
	id bigint identity primary key not null,
	obrisan bit,
	kurs_id bigint foreign key references kursevi(id) not null,
	ucenik_id bigint foreign key references ucenici(id) not null,
	iznos float(6) not null,
	datum date
);

insert into nastavnici
values (0,'Piter', 'Puska','264','250000')

insert into korisnici values
(0,'Marko','Lepan','1234','a', 'a',1)
insert into korisnici values
(0,'Janosa','VidPeru','4321','b', 'b',0)
insert into korisnici values
(1,'Biljezi','Nelaz','4668','c', 'c',0)


insert into skola
	 values
		('Equilibrio', 'Brace Jerkovica 3 Beograd', '011/222-333','info@equilibrio.com', 'equilbrio.com','136548', '2485', '333-335-65')

insert into nastavnici values(0,'Drazen','Stanisic','6874348','35000');
insert into nastavnici values(0,'Jadran','Lazic','4846864','32500');
insert into nastavnici values(0,'Anita','Topalovic','468684','27800');
insert into nastavnici values(0,'Sladjana','Maksimovic','488786846','4000');
insert into nastavnici values(0,'Filip','Blagojevic','486846','18000');
insert into nastavnici values(0,'Bojana','Ilic','1331','21000');
insert into nastavnici values(0,'Stefan','Todorovic','7788','21300');
insert into nastavnici values(0,'Adrijana','Filipovic','1313','22500');
insert into nastavnici values(0,'Dragan','Gajic','11158','26900');
insert into nastavnici values(0,'Tijana','Mladjenovic','8468864','29800');
insert into nastavnici values(0,'Mladenka','Romcevic','135313','31000');


insert into ucenici values(0,'Vera','Zalica','645642');
insert into ucenici values(0,'Nemanja','Grujic','654577');
insert into ucenici values(0,'Bozana','Bibercic','786721');
insert into ucenici values(0,'Bojana','Savic','7854446');
insert into ucenici values(0,'Dusan','Stefanovic','5735700');
insert into ucenici values(0,'Milena','Kojic','987664');
insert into ucenici values(0,'Nevena','Milosavljevic','468877');
insert into ucenici values(0,'Dejan','Nenadovic','6571445');
insert into ucenici values(0,'Tijana','Lasic','478562');
insert into ucenici values(0,'Miroslav','Jovanovic','968574');
insert into ucenici values(0,'Ivana','Karetic','978576');
insert into ucenici values(0,'Bojana','Peric','654879');
insert into ucenici values(0,'Sreten','Tadic','789654');
insert into ucenici values(0,'Milos','Mitrovic','153246');
insert into ucenici values(0,'Mustafa','Peric','635241');
insert into ucenici values(0,'Aleksandra','Bokan','415263');
insert into ucenici values(0,'Maja','Bekut','362514');
insert into ucenici values(0,'Ana','Radovanovic','142536');
insert into ucenici values(0,'Mirjana','Micic','654321');
insert into ucenici values(0,'Radenko','Ivanovic','123456');

insert into kursevi values(0,'Spanski','B1',3000,1);
insert into kursevi values(0,'Francuski','FFC',6579,7);
insert into kursevi values(0,'Nemacki','C1.1',8990,5);
insert into kursevi values(0,'Makedonski','A1',4900,8);
insert into kursevi values(0,'Finski','B2.2',6589,9);


insert into predaje values(1,1);
insert into predaje values(2,2);
insert into predaje values(3,3);
insert into predaje values(4,4);
insert into predaje values(5,5);


insert into pohadja values(1,1);
insert into pohadja values(2,1);
insert into pohadja values(3,2);
insert into pohadja values(4,2);
insert into pohadja values(5,2);
insert into pohadja values(2,3);
insert into pohadja values(2,4);


insert into uplate values(0, 1, 1, 3000, '11-12-2016');
insert into uplate values(0, 1, 2, 3500, '11-12-2016');
insert into uplate values(0, 2, 3, 4000, '12-18-2016');
insert into uplate values(0, 2, 4, 2960, '12-19-2016');
insert into uplate values(0, 2, 5, 800, '12-19-2016');
insert into uplate values(0, 3, 2, 6550, '01-01-2017');