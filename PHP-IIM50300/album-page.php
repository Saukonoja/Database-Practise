<?php
session_start();
require_once("db-init-music.php");



include("select-queries/album-tracks-query.php");
include("select-queries/track-tubepath-query.php");

if(isset($_GET['link_album'])){
    $_SESSION['album'] = $_GET['link_album'];
}
if(isset($_GET['link_track'])){
    $_SESSION['track'] = $_GET['link_track'];
}
include("header.php");

$result = $conn->query($sql);

echo '<div id="content-layout">';
echo '<div id="content">';
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

        
    	echo '<tr><td id=number>' . $row["numero"]. "</td><td id=track><a href='album-page.php?link_track=".$row["kappale"]."'>" . $row["kappale"]. '</td><td id=length>' 
        . gmdate("i:s", $row["kesto"]). '</td>'; 
    }
    echo '<p id="albumInfo">from artist <span id="artist"><a href="artist-page.php?link_artist="fsdf">'.$artist.'</a></span> &#9679; '.$year.' &#9679; '.$row_count. ' tracks, '
    .gmdate("i:s", $length).'</p>';
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
             echo "<object width='60%' height='400' data='http://www.youtube.com/v/".$tube."?autoplay=1' type='application/x-shockwave-flash'><param name='src' value='http://www.youtube.com/v/".$tube."?autoplay=1'/></object>";
        }
    }
}          
		echo '</div>';
	echo '</div>';
echo '</div>';
$conn->close();
include("footer.php");

?>