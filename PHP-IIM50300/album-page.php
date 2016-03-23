<?php
session_start();
require_once("db-init-music.php");

include("album-tracks-query.php");
include("track-tubepath-query.php");

include("header.php");

$result = $conn->query($sql);
if(isset($_GET['link_album'])){
        $_SESSION['album'] = $_GET['link_album'];
}

echo '<div id="content-layout">';
echo '<div id="content">';
echo '<h2>'.$_SESSION['album'].'</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Number</th><th>Track</th><th>Length</th><th>Album</th><th>Year</th></tr>';
    while($row = $result->fetch_assoc()) {
    	echo "<tr><td>" . $row["numero"]. "</td><td><a href='album-page.php?link_track=".$row["kappale"]."'>" . $row["kappale"]. '</td><td>' . $row["kesto"]. '</td><td>' . $row["levy"]. '</td><td>'. $row["julkaisuvuosi"] . '</td></tr>';
    }
    echo '</table>';
} else {
    echo "0 results";
}

if(isset($_GET['link_track'])){
    $_SESSION['track'] = $_GET['link_track'];
    $result2 = $conn->query($sql2);
    $tube = '';
    if($result2->num_rows > 0){
        if($row = $result2->fetch_assoc()){
            $tube = $row['tubepath'];
             echo "<object width='600' height='400' data='http://www.youtube.com/v/".$tube."' type='application/x-shockwave-flash'><param name='src' value='http://www.youtube.com/v/".$tube."'/></object>";
        }
    }
}          
		echo '</div>';
	echo '</div>';
echo '</div>';
$conn->close();
include("footer.php");

?>