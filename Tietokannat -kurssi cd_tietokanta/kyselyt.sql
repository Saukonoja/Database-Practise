declare @i int;
set @i = 1949;

while @i <= 2020
begin
   insert into vuosi (vuosi) values(@i);
   set @i = @i + 1;
end;
go

insert into maa (isoalpha2, nimi) values( 'SE', 'Sweden');
insert into maa (isoalpha2, nimi) values( 'US', 'United States of America');

insert into yhtio (nimi, maa_avain, vuosi_avain) values( 'Epic Records', (select avain from maa where nimi = 'United States of America'), (select avain from vuosi where vuosi = '1953'));

insert into esittaja (nimi, maa_avain, vuosi_avain) values( 'Europe', (select avain from maa where nimi = 'Sweden'), (select avain from vuosi where vuosi = '1979'));
insert into esittaja (nimi, maa_avain, vuosi_avain) values( 'Iron Maiden', (select avain from maa where nimi = 'United States of America'), (select avain from vuosi where vuosi = '1975'));

insert into cd (nimi, yhtio_avain, vuosi_avain, kuvapath) values( 'The Final Countdown', (select avain from yhtio where nimi = 'Epic Records'), (select avain from vuosi where vuosi = '1986'),'');
insert into cd (nimi, yhtio_avain, vuosi_avain, kuvapath) values( 'Fear of the Dark', (select avain from yhtio where nimi = 'Epic Records'), (select avain from vuosi where vuosi = '1992'),'');

insert into genre (nimi) values( 'Hard Rock');
insert into genre (nimi) values( 'Heavy Metal');

insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'The Final Countdown', '311', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'', '1');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Rock the Night', '243', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'', '2');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Carrie', '270', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','3');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Danger on the Track', '225', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','4');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Ninja', '226', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','5');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Cherokee', '253', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','6');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Time Has Come', '241', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','7');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Heart of Stone', '226', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','8');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'On the Loose', '188', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','9');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Love Chaser', '207', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'','10');

insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Be Quick or Be Dead', '204', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','1');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'From Here to Eternity', '218', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','2');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Afraid to Shoot Strangers', '416', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','3');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Fear Is the Key', '335', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','4');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Childhood''s'' End', '280', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','5');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Wasting Love', '350', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','6');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'The Fugitive', '294', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','7');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Chains of Misery', '217', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','8');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'The Apparition', '234', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','9');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Judas Be My Guide', '188', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','10');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Weekend Warrior', '339', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','11');
insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'Fear of the Dark', '438', (select avain from esittaja where nimi = 'Iron Maiden'), (select avain from vuosi where vuosi = '1992'),'','12');

insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'The Final Countdown'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Rock the Night'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Carrie'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Danger on the Track'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Ninja'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Cherokee'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Time Has Come'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Heart of Stone'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'On the Loose'), (select avain from genre where nimi = 'Hard Rock'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Love Chaser'), (select avain from genre where nimi = 'Hard Rock'));

insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Be Quick or Be Dead'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'From Here to Eternity'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Afraid to Shoot Strangers'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Fear Is the Key'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Childhood''s'' End'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Wasting Love'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'The Fugitive'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Chains of Misery'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'The Apparition'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Judas Be My Guide'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Weekend Warrior'), (select avain from genre where nimi = 'Heavy Metal'));
insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'Fear of the Dark'), (select avain from genre where nimi = 'Heavy Metal'));

insert into cd_esittaja (cd_avain, esittaja_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from esittaja where nimi = 'Europe'));
insert into cd_esittaja (cd_avain, esittaja_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from esittaja where nimi = 'Iron Maiden'));

insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'The Final Countdown'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Rock the Night'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Carrie'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Danger on the Track'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Ninja'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Cherokee'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Time Has Come'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Heart of Stone'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'On the Loose'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'Love Chaser'));

insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Be Quick or Be Dead'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'From Here to Eternity'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Afraid to Shoot Strangers'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Fear Is the Key'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Childhood''s'' End'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Wasting Love'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'The Fugitive'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Chains of Misery'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'The Apparition'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Judas Be My Guide'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Weekend Warrior'));
insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'Fear of the Dark'), (select avain from kappale where nimi = 'Fear of the Dark'));

-- BASIC QUERIES---------------------

-- Kaikki artistit tulostetaan

select 
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Perustamisvuosi,
	maa.nimi as Maa
from esittaja 
left join vuosi on esittaja.vuosi_avain = vuosi.avain
left join maa on esittaja.maa_avain = maa.avain;


-- Kaikki albumit tulostetaan

select 
	cd.nimi as Levy,
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Julkaisuvuosi,
	yhtio.nimi as Yhtio
from cd 
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain;


-- Kaikki kappaleet tulostetaan

select 
		kappale.nimi as Kappale,
		esittaja.nimi as Esittaja,
		cd.nimi as Levy,
		vuosi.vuosi as Julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain;

-- Kaikki genret tulostetaan

select 
	genre.nimi as Genre 
from genre;

-- Kappaleet tulostetaan aakkosjärjestyksessä genren mukaan

select 
	kappale.nimi as Kappale,
	genre.nimi as Genre
from kappale
left join kappale_genre on kappale_genre.kappale_avain = kappale.avain
left join genre on kappale_genre.genre_avain = genre.avain
ORDER BY genre.nimi, kappale.nimi

-- Kaikki levy-yhtiöt tulostetaan

select 
		yhtio.nimi as Levyyhtio,
		maa.nimi as Maa,
		vuosi.vuosi as Perustamisvuosi
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain;

-- Kaikki artistin levyt tulostetaan

select 
	cd.nimi as Levy,
	esittaja.nimi as Esittaja,
	vuosi.vuosi as Julkaisuvuosi,
	yhtio.nimi as Yhtio
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = 'Europe');

-- Kaikki levyn kappaleet tulostetaan

select 
		kappale.nimi as Kappale,
		kappale.kesto as Kesto,
		cd.nimi as Levy,
		vuosi.vuosi as Julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown');


-- ADVANCED QUERIES--------------------


-- Albumin kappaleiden kestojen keskiarvo tulostetaan

select
		avg(kappale.kesto)
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown');

-- Kaikki albumin kappaleet, joiden kesto on alle 5 minuuttia tulostetaan keston mukaan järjestyksessä

select
		kappale.nimi as kappale,
		kappale.kesto as kesto,
		cd.nimi as levy
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown')
and kappale.kesto < 300
group by kappale.kesto;

-- Jos artistin albumilla on yli kymmenen kappaletta niin se tulostetaan näkyviin

select 
	cd.nimi as Levy
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = 'Iron Maiden')
and exists
			 (
			 select
				cd.nimi
				from cd
			left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
			left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
				 where cd.nimi = 'Fear of the Dark') 
				 and (
			select 
				count(kappale.nimi) as kappale
			from cd
			left join cd_kappale on cd_kappale.cd_avain = cd.avain
			left join kappale on cd_kappale.kappale_avain = kappale.avain
			where cd.nimi = 'Fear of the Dark' 
			having count(kappale.nimi) > 10);


-- Albumin nimi tulostetaan ja kappalemäärä, jos levyllä on yli 10 kappaletta

select 
		cd.nimi as levy,
		count(kappale.nimi) as kappaleita
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd.nimi = 'Fear of the Dark' 
having count(kappale.nimi) > 10;  

-- Albumin kappaleet sekoitetaan ja valitaan aina yksi näkyviin, voisi toimia esimerkiksi albumia kuunneltaessa ns. shufflena

select
  kappale.nimi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'Fear of the Dark')
order by rand() limit 1;


-- Etsitään taulusta cd sen nimisiä albumeita joiden nimessä esiintyy jossain kohtaa kirjain 'F'


select
 * 
from cd 
where cd.nimi like '%F%'; 


-- Etsitään kahdesta eri taulusta hakusanalla

select 
  cd.nimi as Levy,
  esittaja.nimi as Esittaja,
  vuosi.vuosi as Julkaisuvuosi,
  yhtio.nimi as Yhtio
from cd 
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd.nimi like '%1986%' or esittaja.nimi like '%1986%' or vuosi.vuosi like '%1986%' or yhtio.nimi like '%1986%' 


-- Muutetaan kaikki kuvatpath kentät null valuesta tyhjäksi loopin sisällä

declare @i int;
set @i = 1;

while @i <= (select max(avain) from cd)
begin
	update cd set kuvapath = '' where avain = @i and exists (select avain from cd where kuvapath is null)
   set @i = @i + 1;
end;
go

