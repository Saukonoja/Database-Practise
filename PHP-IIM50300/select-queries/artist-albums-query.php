<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'album';  

include("sort.php");


$sql = 
"select 
  cd.nimi as album,
  vuosi.vuosi as year,
  yhtio.nimi as company
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = ?)
order by $sort $sort_order;"

?>