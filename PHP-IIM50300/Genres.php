<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

include("select-queries/all-genres-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>Genres</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Genre</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newGenre = new Genre($row["genre"]);
        echo $newGenre;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>