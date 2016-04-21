<?php

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'genre';  

include($sortLink);

$sql = 
"select 
	genre.nimi as genre
from genre
order by $sort $sort_order;";

?>