-- insert into vuosi with loop:

drop procedure if exists my_procedure;

delimiter #

create procedure my_procedure () 
begin

DECLARE i INT DEFAULT 1949;

  WHILE i < 2031 DO
  insert into vuosi (vuosi) values(i);
  /* insert into table... */
  SET i = i + 1;
  END WHILE;

end# -- end of stored procedure block

delimiter ; -- switch delimiters again

call my_procedure();

insert into maa (isoalpha2, nimi) values( 'SE', 'Sweden');

insert into yhtio (nimi, maa_avain, vuosi_avain) values( 'Epic Records', (select avain from maa where nimi = 'United States of America'), (select avain from vuosi where vuosi = '1953'));

insert into esittaja (nimi, maa_avain, vuosi_avain) values( 'Europe', (select avain from maa where nimi = 'Sweden'), (select avain from vuosi where vuosi = '1979'));

insert into genre (nimi) values( 'Hard Rock');

insert into kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) values( 'The Final Countdown', '311', (select avain from esittaja where nimi = 'Europe'), (select avain from vuosi where vuosi = '1986'),'fdsa6dd21sf', '1');

insert into kappale_genre (kappale_avain, genre_avain) values( (select avain from kappale where nimi = 'The Final Countdown'), (select avain from genre where nimi = 'Hard Rock'));

insert into cd (nimi, yhtio_avain, vuosi_avain, kuvapath) values( 'The Final Countdown', (select avain from yhtio where nimi = 'Epic Records'), (select avain from vuosi where vuosi = '1986'),'test');

insert into cd_kappale (cd_avain, kappale_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from kappale where nimi = 'The Final Countdown'));

insert into cd_esittaja (cd_avain, esittaja_avain) values( (select avain from cd where nimi = 'The Final Countdown'), (select avain from esittaja where nimi = 'Europe'));

insert into user (tunnus, salasana, tyyppi) values( 'janne', 'sala','1');
