<?php

$track = $_SESSION['track'];

$sql2 = 
"select 
	tubepath 
from kappale
where kappale.nimi = '$track';"

?>