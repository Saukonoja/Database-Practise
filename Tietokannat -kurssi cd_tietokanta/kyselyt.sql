-- BASIC QUERIES

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


-- ADVANCED QUERIES


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
