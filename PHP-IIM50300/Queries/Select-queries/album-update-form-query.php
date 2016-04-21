<?php

$id=$_SESSION['id'];

   $sql = 
	"SELECT cd.avain as id, cd.nimi as nimi, esittaja.nimi as esittaja, vuosi.vuosi as vuosi, yhtio.nimi as yhtio, kuvapath
	   FROM cd
	   left join cd_esittaja on cd_esittaja.cd_avain = cd.avain
	   left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain
	   left join vuosi on cd.vuosi_avain = vuosi.avain
	   left join yhtio on cd.yhtio_avain = yhtio.avain
	   WHERE cd.avain = '$id';"
?>