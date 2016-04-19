<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'username';  
 
include("sort.php");
 
$sql = "select 
  tunnus as username,
  tyyppi as admin,
  avain as ID
from user
order by $sort $sort_order;";


?>