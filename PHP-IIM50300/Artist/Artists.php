<?php

include("../Init/header.php");

require_once($artistClass);

require_once($dbInit);

$_SESSION['current'] = "Artists";

include($allArtistsQuery);

$result = $conn->prepare($sql);
$result->execute();

include($artistTable);

include($footer);

?>