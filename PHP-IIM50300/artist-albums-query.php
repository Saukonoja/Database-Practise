<?php

$artist = $_SESSION['artist'];

$sql = 
"select 
  c.nimi as levy,
  e.nimi as esittaja,
  v.vuosi as julkaisuvuosi,
  y.nimi as yhtio
from cd as c 
left join cd_esittaja as cd on cd.cd_avain = c.avain
left join esittaja as e on cd.esittaja_avain = e.avain
left join vuosi as v on c.vuosi_avain = v.avain
left join yhtio as y on c.yhtio_avain = y.avain
where cd.esittaja_avain = (select avain from esittaja where nimi = '$artist');"

?>