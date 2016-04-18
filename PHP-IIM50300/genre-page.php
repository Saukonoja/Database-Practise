<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}
require_once("db-init-music.php");

if(isset($_GET['link_genre'])){
        $_SESSION['genre'] = $_GET['link_genre'];
}

include("select-queries/genre-tracks-query.php");


$result = $conn->query($sql);

echo '<h1>'.$_SESSION['genre'].'</h1>';
if ($result->num_rows > 0) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=track&sort_by='.$sort_order.'" id="headerLink">Track</a></th>
              <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    while($row = $result->fetch_assoc()) {
        $newGenreTrack = new GenreView($row["track"], $row["artist"], $row['album'], $row['year']);
        echo $newGenreTrack;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>