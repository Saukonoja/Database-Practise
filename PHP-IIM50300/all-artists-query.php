<?php

$sql = "select 
  e.nimi as esittaja,
  v.vuosi as perustamisvuosi,
  m.nimi as maa
from esittaja as e 
left join vuosi as v on e.vuosi_avain = v.avain
left join maa as m on e.maa_avain = m.avain;"

?>