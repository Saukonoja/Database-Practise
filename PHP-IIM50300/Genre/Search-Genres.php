<?php

require_once($genreClass);

require_once($dbInit);

include($allGenresSearchQuery);

$result = $conn->prepare($sql);
$result->bind_param('s', $search);
$result->execute();

include($genreTable);

include($footer);


?>