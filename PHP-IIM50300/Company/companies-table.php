<?php

echo '<h1 id="pageHeader">Record companies</h1>';
$result->bind_result($company, $country, $year);
if ($result) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Company</a></th>
    		  <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th>
    		  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    while ($result->fetch()) {
    	$newCompany = new Company($company, $country, $year);
        echo $newCompany;
    }
    echo '</table>';
} else {
    echo "0 results";
}

$conn->close();

?>