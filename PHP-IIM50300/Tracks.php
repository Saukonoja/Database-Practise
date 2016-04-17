<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/all-tracks-query.php");



$trackPage = 0;

if(isset($_GET["page"])){
    $page = $_GET["page"];

    if($page == "" || $page == "1"){
        $page1 = 0;
        $trackPage = $page1;
    } else{
        $page1 = ($page * 10) - 10;
        $trackPage = $page1;
    }   
} else{
    $page = 1;
}

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'track';  

include("sort.php");

$sql =
"select 
        kappale.nimi as track,
        esittaja.nimi as artist,
        cd.nimi as album,
        vuosi.vuosi as year
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
order by $sort $sort_order
limit $trackPage,10;";



$result = $conn->query($sql);

echo '<h1>Tracks</h1>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=track&sort_by='.$sort_order.'" id="headerLink">Track</a></th>
              <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    $row_count = $result->num_rows;
    while($row = $result->fetch_assoc()) {
        $newTrack = new Track($row["track"], $row["artist"], $row['album'], $row['year']);
        echo $newTrack;
    }
    echo '</table>';
    
} else {
    echo "0 results";
}

$result2 = $conn->query($sql2);

$prev = $page - 1;
$next = $page + 1;

echo '<br>';
echo '<div id="linkContainer">';
if ($page > 1){
    echo "<a href='Tracks?page=$prev' id='prevLink'>Prev</a>";
}

if ($result2->num_rows > 0){
    $row_count = $result2->num_rows;
    $decimal = $row_count / 10;

    $numberOfPages = ceil($decimal);

    for($i = 1; $i <= $numberOfPages; $i++){
        echo ($i == $page) ? "<b><a href='Tracks?page=". $i. "' id='pageCurrentLink'>" .$i. "</a></b>" : "<a href='Tracks?page=". $i. "' id='pageLink'>" .$i. "</a>";
    }
}

if ($page < $numberOfPages){
    echo "<a href='Tracks?page=$next' id='nextLink'>Next</a>";
}
echo '</div>';

$conn->close();

include("footer.php");

?>
