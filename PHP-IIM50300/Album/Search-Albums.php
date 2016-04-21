<?php

require_once($albumClass);

require_once($dbInit);

include($allAlbumsSearchQuery);

$result = $conn->prepare($sql);
$result->bind_param('ssss', $search, $search, $search, $search);
$result->execute();

include($albumTable);

include($footer);

?>