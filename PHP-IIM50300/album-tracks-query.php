<?php

$album = $_SESSION['album'];

$sql =
"select
	kappale.numero as numero, 
	kappale.nimi as kappale,
    kappale.kesto as kesto,
    cd.nimi as levy,
    esittaja.nimi as esittaja,
    vuosi.vuosi as julkaisuvuosi
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = '$album')
group by kappale.numero";

?>