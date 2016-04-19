<?php

$sql =
"update esittaja 
	set nimi = ?, 
	maa_avain = (select avain from maa where nimi = ?), 
	vuosi_avain = (select avain from vuosi where vuosi = ?)
where avain = ?;"; 

?>