<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

if(isset($_GET['link_artist'])){
        $_SESSION['artist'] = $_GET['link_artist'];
}

include("select-queries/artist-albums-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h1>'.$_SESSION['artist'].'</h1>';
if ($result->num_rows > 0) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
              <th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Record company</a></th></tr>';
    while($row = $result->fetch_assoc()) {
        $newArtistAlbum = new ArtistView($row["album"], $row["year"], $row['company']);
        echo $newArtistAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>