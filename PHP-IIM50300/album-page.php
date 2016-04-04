<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

if(isset($_GET['link_album'])){
    $_SESSION['album'] = $_GET['link_album'];
}

if(isset($_GET['link_track'])){
    $_SESSION['track'] = $_GET['link_track'];
}


include("select-queries/album-tracks-query.php");
include("select-queries/track-tubepath-query.php");

include("header.php");


$result = $conn->query($sql);


echo '<h2 id="albumTitle">'.$_SESSION['album'].'</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>#</th><th>Track</th><th>Length</th></tr>';
    $found = 0;
    $row_count = $result->num_rows;
    $length = 0;
    while($row = $result->fetch_assoc()) {      
        if($found == 0){
            $found = 1;
            $artist = $row["esittaja"];
            $year = $row['julkaisuvuosi'];
        }

        $length += $row['kesto'];

        $newAlbumTrack = new AlbumView($row["numero"], $row["kappale"], $row['kesto']);
        echo $newAlbumTrack;
    }
    echo $newAlbumTrack->albumInfo($artist, $year, $row_count, $length);

    echo '</table>';
} else {
    echo "0 results";
}

if(isset($_GET['link_track'])){
    $result2 = $conn->query($sql2);
    $tube = '';
    if($result2->num_rows > 0){
        if($row = $result2->fetch_assoc()){
            $tube = $row['tubepath'];
             echo $newAlbumTrack->youtubeVideo($tube);
        }
    }
}          

$conn->close();

include("footer.php");

?>