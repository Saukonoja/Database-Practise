<?php

include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}
require_once("db-init-music.php");
if(isset($_GET['link_artist'])){
        $artist = $_GET['link_artist'];
}
echo '<h1>'.$artist.'</h1>';
include("select-queries/artist-albums-query.php");
$result = $conn->prepare($sql);
$result->bind_param('s', $artist);
$result->execute();

if ($result->bind_result($album, $year, $company)) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
              <th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Record company</a></th></tr>';
    while($result->fetch()) {
        $newArtistAlbum = new ArtistView($album, $year, $company);
        echo $newArtistAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>