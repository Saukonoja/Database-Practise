<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

if(isset($_GET['link_genre'])){
        $_SESSION['genre'] = $_GET['link_genre'];
}

include("select-queries/genre-tracks-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>'.$_SESSION['genre'].'</h2>';
if ($result->num_rows > 0) {
    echo '<table class="query">';
    echo '<tr><th>Track</th><th>Artist</th><th>Album</th><th>Year</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newGenreTrack = new GenreView($row["kappale"], $row["esittaja"], $row['levy'], $row['julkaisuvuosi']);
        echo $newGenreTrack;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>