<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'artist';  

include("sort.php");

$sql = "select 
  esittaja.nimi as esittaja,
  vuosi.vuosi as perustamisvuosi,
  maa.nimi as maa,
  esittaja.avain as ID
from esittaja
left join vuosi on esittaja.vuosi_avain = vuosi.avain
left join maa on esittaja.maa_avain = maa.avain
order by $sort $sort_order;";

?>