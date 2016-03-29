
--basic queries

-- Kaikki artistit tulostetaan
select 
  e.nimi as Esittaja,
  v.vuosi as Perustamisvuosi,
  m.nimi as Maa
from esittaja as e 
left join vuosi as v on e.vuosi_avain = v.avain
left join maa as m on e.maa_avain = m.avain;


-- Kaikki albumit tulostetaan
select 
  c.nimi as Levy,
  e.nimi as Esittaja,
  v.vuosi as Julkaisuvuosi,
  y.nimi as Yhtio
from cd as c 
left join cd_esittaja as cd on cd.cd_avain = c.avain
left join esittaja as e on cd.esittaja_avain = e.avain
left join vuosi as v on c.vuosi_avain = v.avain
left join yhtio as y on c.yhtio_avain = y.avain;


-- Kaikki kappaleet tulostetaan

select 
	k.nimi as Kappale,
    e.nimi as Esittaja,
    c.nimi as Levy,
    v.vuosi as Julkaisuvuosi
from cd as c
left join cd_kappale as cd on cd.cd_avain = c.avain
left join kappale as k on cd.kappale_avain = k.avain
left join esittaja as e on k.esittaja_avain = e.avain
left join vuosi as v on k.vuosi_avain = v.avain;

-- Kaikki genret tulostetaan

select genre.nimi as Genre from genre;


-- Kaikki levy-yhtiöt tulostetaan
select 
	y.nimi as Levyyhtio,
    m.nimi as Maa,
    v.vuosi as Perustamisvuosi
from yhtio as y
left join maa as m on y.maa_avain = m.avain
left join vuosi as v on y.vuosi_avain = v.avain;

-- Kaikki artistin levyt tulostetaan

select 
  c.nimi as Levy,
  e.nimi as Esittaja,
  v.vuosi as Julkaisuvuosi,
  y.nimi as Yhtio
from cd as c 
left join cd_esittaja as cd on cd.cd_avain = c.avain
left join esittaja as e on cd.esittaja_avain = e.avain
left join vuosi as v on c.vuosi_avain = v.avain
left join yhtio as y on c.yhtio_avain = y.avain
where cd.esittaja_avain = (select avain from esittaja where nimi = 'Europe');

-- Kaikki levyn kappaleet tulostetaan

select 
	k.nimi as Kappale,
    k.kesto as Kesto,
    c.nimi as Levy,
    v.vuosi as Julkaisuvuosi
from cd as c
left join cd_kappale as cd on cd.cd_avain = c.avain
left join kappale as k on cd.kappale_avain = k.avain
left join vuosi as v on k.vuosi_avain = v.avain
where cd.cd_avain = (select avain from cd where nimi = 'The Final Countdown');


select 
	kuvapath 
from cd
where cd.nimi = 'test';


--advanced queries

-- Albumin kappaleiden kestojen keskiarvo tulostetaan

select
    avg(kappale.kesto)
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown')

-- Kaikki albumin kappaleet, joiden kesto on alle 5 minuuttia tulostetaan keston mukaan järjestykssä

select
	kappale.nimi as kappale,
    kappale.kesto as kesto,
    cd.nimi as levy
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = 'The Final Countdown')
and kappale.kesto < 300
group by kappale.kesto









