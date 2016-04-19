<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'album';  

include($sortLink);

$company = $_SESSION['company'];

$sql = 

"select
	 cd.nimi as album,
	 esittaja.nimi as artist, 
	 vuosi.vuosi as year 
from cd 
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain 
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain 
left join vuosi on cd.vuosi_avain = vuosi.avain 
left join yhtio on cd.yhtio_avain = yhtio.avain 
where cd.yhtio_avain = (select avain from yhtio where nimi = '$company')
order by $sort $sort_order;";


?>