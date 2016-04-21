<?php

$trackPage = 0;

if (isset($_GET["page"])){
    $page = $_GET["page"];

    if($page == "" || $page == "1"){
        $page1 = 0;
        $trackPage = $page1;
    } else{
        $page1 = ($page * 10) - 10;
        $trackPage = $page1;
    }   
} else{
    $page = 1;
}

echo '<h1>Tracks</h1>';

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'track';  
include($sortLink);
$sql =
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
where kappale.nimi like ?
or esittaja.nimi like ?
or cd.nimi like ?
or vuosi.vuosi like ?
order by $sort $sort_order
limit $trackPage,20;";
?>