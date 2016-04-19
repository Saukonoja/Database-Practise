<?php

include("../Init/header.php");

require_once($albumClass);

$_SESSION['current'] = "Albums";

require_once($dbInit);

include($allAlbumsQuery);

$result = $conn->prepare($sql);
$result -> execute();

include($albumTable);

include($footer);

?>