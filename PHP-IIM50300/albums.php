<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>Albums</h2>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
    echo '<tr><th>Album</th><th>Artist</th><th>Year</th><th>Record company</th></tr>';
    while($row = $result->fetch_assoc()) {  	
        $newAlbum = new Album($row["levy"], $row["esittaja"], $row["julkaisuvuosi"], $row['yhtio']);
        echo $newAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>