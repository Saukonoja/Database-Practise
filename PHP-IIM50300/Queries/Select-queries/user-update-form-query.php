<?php

$id = $_SESSION['id'];

$sql = 

"select 
	tunnus as username, 
	tyyppi as admin, 
	avain as ID 
from user
where avain = '$id';";


?>