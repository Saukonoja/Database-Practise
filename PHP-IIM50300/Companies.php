﻿<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

include("select-queries/all-companies-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>Record companies</h2>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Company</a></th>
    		  <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th>
    		  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    while($row = $result->fetch_assoc()) {
    	$newCompany = new Company($row["company"], $row["country"], $row["year"]);
        echo $newCompany;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>