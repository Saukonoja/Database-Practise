﻿<?php
session_start();
require_once("db-init-music.php");

include("all-artists-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<div id="content-layout">';
echo '<div id="content">';
echo '<h2>Artists</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Artist</th><th>Year</th><th>Country</th></tr>';
    while($row = $result->fetch_assoc()) {
    	echo "<tr><td><a href='artist-page.php?link_artist=".$row["esittaja"]."'>" . $row["esittaja"]. '</a></td><td>' . $row["perustamisvuosi"]. '</td><td>' . $row["maa"] . '</td></tr>';
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