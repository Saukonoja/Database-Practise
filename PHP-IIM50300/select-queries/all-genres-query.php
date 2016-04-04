<?php

$sql = 
"select 
	kappale.nimi as kappale,
	genre.nimi as genre
from kappale
left join kappale_genre on kappale_genre.kappale_avain = kappale.avain
left join genre on kappale_genre.genre_avain = genre.avain
ORDER BY genre.nimi, kappale.nimi;";

?>