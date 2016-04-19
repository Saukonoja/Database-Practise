<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'company';  

include("sort.php");

$search = $_SESSION['search'];

$sql = 
"select 
		yhtio.nimi as company,
		maa.nimi as country,
		vuosi.vuosi as year
from yhtio
left join maa on yhtio.maa_avain = maa.avain
left join vuosi on yhtio.vuosi_avain = vuosi.avain
where yhtio.nimi like '%$search%'
or maa.nimi like '%$search%'
or vuosi.vuosi like '%$search%'
order by $sort $sort_order;"


?>