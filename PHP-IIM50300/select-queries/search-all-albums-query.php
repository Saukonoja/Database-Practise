<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'album';  

include("sort.php");

$search = $_SESSION['search'];

$sql = 
"select 
  cd.nimi as album,
  esittaja.nimi as artist,
  vuosi.vuosi as year,
  yhtio.nimi as company
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja  on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd.nimi like '%$search%'
or esittaja.nimi like '%$search%'
or vuosi.vuosi like '%$search%'
or yhtio.nimi like '%$search%'
order by $sort $sort_order;"

?>