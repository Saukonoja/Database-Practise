<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'artist';  

include("sort.php");

$sql = "select 
  esittaja.nimi as artist,
  vuosi.vuosi as year,
  maa.nimi as country,
  esittaja.avain as ID
from esittaja
left join vuosi on esittaja.vuosi_avain = vuosi.avain
left join maa on esittaja.maa_avain = maa.avain
where esittaja.nimi like ?
or vuosi.vuosi like ?
or maa.nimi like ?
order by $sort $sort_order;";

?>