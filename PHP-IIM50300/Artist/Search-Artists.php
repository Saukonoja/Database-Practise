<?php

include("../Init/header.php");

require_once($artistClass);

require_once($dbInit);

$_SESSION['current'] = "Artists";

include($allArtistsSearchQuery);

$result = $conn->prepare("SELECT 
  esittaja.nimi as artist,
  vuosi.vuosi as year,
  maa.nimi as country,
  esittaja.avain as ID
from esittaja
left join vuosi on esittaja.vuosi_avain = vuosi.avain
left join maa on esittaja.maa_avain = maa.avain
where esittaja.nimi like ?
or vuosi.vuosi like ?
or maa.nimi like ?
order by $sort $sort_order;");
$result->bind_param('sss', $search, $search, $search);
$result->execute();

include($artistTable);

include($footer);

?>