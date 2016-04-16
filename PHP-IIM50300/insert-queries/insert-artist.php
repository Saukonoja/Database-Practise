<?php

$sql = "INSERT INTO esittaja (nimi, maa_avain, vuosi_avain)
VALUES(?,(SELECT avain FROM maa WHERE nimi = ?),(SELECT avain FROM vuosi WHERE vuosi = ?));"

?>