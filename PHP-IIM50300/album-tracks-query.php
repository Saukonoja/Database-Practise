<?php

$album = $_SESSION['album'];

$sql =
"select
	k.numero as numero, 
	k.nimi as kappale,
    k.kesto as kesto,
    c.nimi as levy,
    v.vuosi as julkaisuvuosi
from cd as c
left join cd_kappale as cd on cd.cd_avain = c.avain
left join kappale as k on cd.kappale_avain = k.avain
left join vuosi as v on k.vuosi_avain = v.avain
where cd.cd_avain = (select avain from cd where nimi = '$album')
group by k.numero";


?>