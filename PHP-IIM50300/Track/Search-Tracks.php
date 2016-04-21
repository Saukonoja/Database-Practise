<?php
require_once($trackClass);

require_once($dbInit);

include($allTracksSearchQuery);

$result = $conn->prepare($sql);
$result->bind_param('ssss', $search, $search, $search, $search);
$result->execute();

include($trackTable);

include($footer);

?>

