<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'genre';  

include("sort.php");

$search = $_SESSION['search'];

$sql = 
"select 
	genre.nimi as genre
from genre
where genre.nimi like '%$search%'
order by $sort $sort_order;";


?>