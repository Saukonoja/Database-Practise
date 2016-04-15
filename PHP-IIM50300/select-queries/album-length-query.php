<?php

$album = $_SESSION['album'];


$sql2 = 

"select 
	SEC_TO_TIME(SUM(TIME_TO_SEC(kappale.kesto))) AS totalLength 
from cd 
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain 
where cd_kappale.cd_avain = (select avain from cd where nimi = '$album');";


?>