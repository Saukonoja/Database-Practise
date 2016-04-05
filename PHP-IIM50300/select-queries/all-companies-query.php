<?php

$sql = 
"select 
		yhtio.nimi as yhtio,
		maa.nimi as maa,
		vuosi.vuosi as perustamisvuosi
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain;"


?>