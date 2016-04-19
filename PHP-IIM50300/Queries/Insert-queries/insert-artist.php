<?php

$sql = 
"insert into esittaja (nimi, maa_avain, vuosi_avain)
values (?,(select avain from maa where nimi = ?),
(select avain from vuosi where vuosi = ?));";

?>