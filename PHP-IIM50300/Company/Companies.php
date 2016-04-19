<?php

include("../Init/header.php");

require_once($companyClass);

$_SESSION['current'] = "Companies";

require_once($dbInit);

include($allCompaniesQuery);

include($companyTable);

include($footer);

?>