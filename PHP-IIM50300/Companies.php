<?php
session_start();
require_once("db-init-music.php");

include("select-queries/all-companies-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>Record companies</h2>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
    echo '<tr><th>Name</th><th>Country</th><th>Year</th></tr>';
    while($row = $result->fetch_assoc()) {
    	echo "<tr><td><a href='company-page.php?link_company=".$row["yhtio"]."'>" . $row["yhtio"]. '</a></td><td>' . $row["maa"]. '</td><td>' . $row["perustamisvuosi"]. '</td></tr>';
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>