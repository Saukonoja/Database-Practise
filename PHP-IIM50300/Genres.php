<?php
session_start();
require_once("db-init-music.php");

include("select-queries/all-genres-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<div id="content-layout">';
echo '<div id="content">';
echo '<h2>Genres</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Name</th><th>Track</th></tr>';
    while($row = $result->fetch_assoc()) {
    	echo "<tr><td><a href='genre-page.php?link_genre=".$row["genre"]."'>" . $row["genre"]. '</a></td><td>' . $row["kappale"]. '</td></tr>';
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