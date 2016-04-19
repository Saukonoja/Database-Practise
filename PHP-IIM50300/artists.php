<?php

include("header.php");

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

$_SESSION['current'] = "Artists";

echo '<h1 id="pageHeader">Artists</h1>';
echo '<form action=\'add-artist-form.php\'><button style='. $display . ' id=btnAdd class="buttons">Add artist</button></form>';

include("select-queries/all-artists-query.php");
require_once("db-init-music.php");
$result = $conn->query($sql);
if ($result->num_rows > 0) {

    echo '<table class="query">';
	echo '<tr><th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
			  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
			  <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th>
        <th id= \'hiddenTh\'>ID</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newArtist = new Artist($row["artist"], $row["year"], $row["country"], $row["ID"]);
        echo $newArtist;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();


include("footer.php");

?>