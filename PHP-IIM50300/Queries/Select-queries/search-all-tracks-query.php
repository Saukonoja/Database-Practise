<?php

$search = $_SESSION['search'];

$sql2 =
"select 
        kappale.nimi as track,
        esittaja.nimi as artist,
        cd.nimi as album,
        vuosi.vuosi as year
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
where cd.nimi like '%$search%'
or kappale.nimi like '%$search%'
or esittaja.nimi like '%$search%'
or cd.nimi like '%$search%'
or vuosi.vuosi like '%$search%'
order by track;";


?>