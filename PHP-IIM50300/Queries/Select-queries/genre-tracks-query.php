<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'track';  

include($sortLink);

$genre = $_SESSION['genre'];

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
left join kappale_genre on kappale_genre.kappale_avain = kappale.avain
left join genre on kappale_genre.genre_avain = genre.avain
where genre.nimi = '$genre'
order by $sort $sort_order;";

?>