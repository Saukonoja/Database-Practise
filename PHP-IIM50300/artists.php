<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();

require_once("db-init-music.php");

include("select-queries/all-artists-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>Artists</h2>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
	echo '<tr><th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
			  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
			  <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th><th id= \'hiddenTh\'>ID</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newArtist = new Artist($row["esittaja"], $row["perustamisvuosi"], $row["maa"], $row["ID"]);
        echo $newArtist;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>