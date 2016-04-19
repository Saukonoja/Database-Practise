<?php

include("../Init/header.php");

require_once($artistClass);

require_once($dbInit);

include($allArtistsSearchQuery);

$result = $conn->prepare($sql);
$result->bind_param('sss', $search, $search, $search);
$result->execute();

include($artistTable);

include($footer);

?>