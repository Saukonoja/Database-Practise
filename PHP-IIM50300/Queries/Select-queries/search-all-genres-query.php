<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'genre';  

include($sortLink);
$search = $_SESSION['search'];
$sql = 
"select 
	genre.nimi as genre
from genre
where genre.nimi like ?
order by $sort $sort_order;";
?>