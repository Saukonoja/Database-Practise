﻿<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'company';  

include($sortLink);

$sql = 
"select 
		yhtio.nimi as company,
		maa.nimi as country,
		vuosi.vuosi as year,
		yhtio.avain as id
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain
order by $sort $sort_order;"

?>