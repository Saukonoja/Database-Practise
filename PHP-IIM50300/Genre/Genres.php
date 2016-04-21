<?php

include("../Init/header.php");

require_once($genreClass);

$_SESSION['current'] = "Genres";

require_once($dbInit);

include($allGenresQuery);


$result = $conn->prepare($sql);
$result->execute();

include($genreTable);

include($footer);

?>