<?php

include("../Init/header.php");

require_once($trackClass);

$_SESSION['current'] = "Tracks";

require_once($dbInit);

include($allTracksPaginationQuery);

$result = $conn->prepare($sql);
$result->execute();

include($trackTable);

include($footer);

?>
