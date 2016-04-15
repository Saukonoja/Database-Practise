<?php


$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'number';  

include("sort.php");


$album = $_SESSION['album'];

$sql =
"select
	kappale.numero as number, 
	kappale.nimi as track,
    kappale.kesto as length,
    cd.nimi as album,
    esittaja.nimi as artist,
    vuosi.vuosi as year
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
where cd_kappale.cd_avain = (select avain from cd where nimi = '$album')
order by $sort $sort_order;";

?>