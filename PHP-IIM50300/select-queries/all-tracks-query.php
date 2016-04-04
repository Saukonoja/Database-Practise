<?php

$page1 = $_SESSION['page1'];

$sql =
"select 
		kappale.nimi as kappale,
		esittaja.nimi as esittaja,
		cd.nimi as levy,
		vuosi.vuosi as julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
group by kappale.nimi
limit 0,5;"

?>