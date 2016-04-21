<?php

require_once($companyClass);

require_once($dbInit);

include($allCompaniesSearchQuery);

$result = $conn->prepare($sql);
$result->bind_param('sss', $search, $search, $search);
$result->execute();

include($companyTable);

include($footer);

?>