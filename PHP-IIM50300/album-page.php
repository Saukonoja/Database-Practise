<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

echo '<h2 id="albumTitle">'.$_SESSION['album'].'</h2>';

require_once("db-init-music.php");

if (isset($_GET['link_album'])){
    $_SESSION['album'] = $_GET['link_album'];
}

if (isset($_GET['link_track'])){
    $_SESSION['track'] = $_GET['link_track'];
}


include("select-queries/album-tracks-query.php");
include("select-queries/album-length-query.php");
include("select-queries/track-tubepath-query.php");

$result = $conn->query($sql);
$album = $_SESSION['album'];

if ($result->num_rows > 0) {
    echo '<table id=albumPage class="query">';
    echo '<tr><th><a href="?sort=number&sort_by='.$sort_order.'" id="headerLink">#</a></th>
              <th><a href="?sort=track&sort_by='.$sort_order.'" id="headerLink">Track</a></th>
              <th><a href="?sort=length&sort_by='.$sort_order.'" id="headerLink">Length</a></th></tr>';
    $found = 0;
    $row_count = $result->num_rows;
    $albumLength = 0;
    while($row = $result->fetch_assoc()) {      
        if($found == 0){
            $found = 1;
            $artist = $row["artist"];
            $year = $row['year'];
        }

        $length = date('i:s', strtotime($row['length']));
        $trimLength = ltrim($length, 0);

        $newAlbumTrack = new AlbumView($row["number"], $row["track"], $trimLength);
        echo $newAlbumTrack;
    }
    
} else {
    echo "0 results";
}

$result2 = $conn->query("select 
    SEC_TO_TIME(SUM(TIME_TO_SEC(kappale.kesto))) AS totalLength 
from cd 
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain 
where cd_kappale.cd_avain = (select avain from cd where nimi = '$album');");
if ($result2->num_rows > 0){
    if ($row = $result2->fetch_assoc()){
        $albumLength = date('H\ \h\ i\ \m\i\n\ s\ \s\e\c', strtotime($row['totalLength']));
        $trimAlbumLength = substr($albumLength, 1);
    }
}
echo $newAlbumTrack->albumInfo($artist, $year, $row_count, $trimAlbumLength);   
echo '</table>';
echo '<div id=player>';



if (isset($_GET['link_track'])){
    echo $_SESSION['track'];

    if ($result3 = $conn->prepare("$sql2")){
        $result3->bind_param('s', $_SESSION['track']);     
        $result3->execute();
        $result3->bind_result($tube);    
        $result3->fetch();
        echo '<h3>' . $_GET['link_track'] . '</h3>';
        echo $newAlbumTrack->youtubeVideo($tube);   
    }
}    
echo '</div>';


$conn->close();

include("footer.php");

?>