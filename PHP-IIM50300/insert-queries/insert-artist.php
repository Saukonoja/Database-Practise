<?php

$sql = "INSERT INTO esittaja (nimi, maa_avain, vuosi_avain) 
                  	VALUES (@NAME, 
                    (SELECT avain FROM maa WHERE nimi = @COUNTRY),
                    (SELECT avain FROM vuosi WHERE vuosi = @YEAR));"

?>