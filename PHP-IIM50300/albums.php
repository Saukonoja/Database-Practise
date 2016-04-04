<?php

require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<div id="content-layout">';
echo '<div id="content">';
echo '<h2>Albums</h2>';
if ($result->num_rows > 0) {
    // output data of each row

    echo '<table class="query">';
    echo '<tr><th>Album</th><th>Artist</th><th>Year</th><th>Record company</th></tr>';
    while($row = $result->fetch_assoc()) {  	
    	echo '<tr><td>' . $row["levy"]. '</td><td>' . $row["esittaja"]. '</td><td>' . $row["julkaisuvuosi"] . '</td><td>' . $row["yhtio"]. '</td></tr>';
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();
		echo '</div>';
	echo '</div>';
echo '</div>';

include("footer.php");

?>