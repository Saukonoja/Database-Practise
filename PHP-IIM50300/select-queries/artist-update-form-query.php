<?php

$id=$_SESSION['id'];

   $sql = 
	"SELECT esittaja.avain as id, esittaja.nimi as nimi, vuosi.vuosi as vuosi, maa.nimi as maa
	   FROM esittaja
	   left join vuosi on esittaja.vuosi_avain = vuosi.avain
	   left join maa on esittaja.maa_avain = maa.avain
	   WHERE esittaja.avain = '$id';"
?>