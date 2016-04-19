<?php

$sql = 
"insert into cd (nimi, yhtio_avain, vuosi_avain, kuvapath)
values (?,(select avain from yhtio where nimi = ?),
(select avain from vuosi where vuosi = ?),
?); 
insert into cd_esittaja(cd_avain, esittaja_avain)
values ((select avain from cd where nimi = ?)
		select avain from esittaja where nimi = ?)
";

?>