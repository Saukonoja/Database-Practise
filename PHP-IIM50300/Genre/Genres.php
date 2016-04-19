<?php

include("../Init/header.php");

require_once($genreClass);

$_SESSION['current'] = "Genres";

require_once($dbInit);

include($allGenresQuery);

include($genreTable);

include($footer);

?>