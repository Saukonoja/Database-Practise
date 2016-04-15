<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'genre';  

include("sort.php");

$sql = 
"select 
	genre.nimi as genre
from genre
order by $sort $sort_order;";

?>