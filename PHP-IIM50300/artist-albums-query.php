<?php

$artist = $_SESSION['artist'];

$sql = 
"select 
  cd.nimi as levy,
  esittaja.nimi as esittaja,
  vuosi.vuosi as julkaisuvuosi,
  yhtio.nimi as yhtio
from cd
left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
left join vuosi on cd.vuosi_avain = vuosi.avain
left join yhtio on cd.yhtio_avain = yhtio.avain
where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = '$artist');"

?>