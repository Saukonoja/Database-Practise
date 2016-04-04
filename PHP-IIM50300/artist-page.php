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

echo '<h2>'.$_SESSION['artist'].'</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Album</th><th>Year</th><th>Record company</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newArtistAlbum = new ArtistView($row["levy"], $row["julkaisuvuosi"], $row['yhtio']);
        echo $newArtistAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>