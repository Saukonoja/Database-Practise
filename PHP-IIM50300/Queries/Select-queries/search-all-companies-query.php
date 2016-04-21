<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'company';  

include($sortLink);

$sql = 
"select 
		yhtio.nimi as company,
		maa.nimi as country,
		vuosi.vuosi as year
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain
where yhtio.nimi like ?
or maa.nimi like ?
or vuosi.vuosi like ?
order by $sort $sort_order;"


?>