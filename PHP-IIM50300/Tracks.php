<?php
session_start();
require_once("db-init-music.php");

include("header.php");

 $page = $_GET["page"];

    if($page == "" || $page == "1"){
        $page1 = 0;
    }   
$sql =
"select 
        kappale.nimi as kappale,
        esittaja.nimi as esittaja,
        cd.nimi as levy,
        vuosi.vuosi as julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
group by kappale.nimi
limit $page1,5;";

$sql2 =
"select 
        kappale.nimi as kappale,
        esittaja.nimi as esittaja,
        cd.nimi as levy,
        vuosi.vuosi as julkaisuvuosi
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
group by kappale.nimi;";

$result = $conn->query($sql);

echo '<div id="content-layout">';
echo '<div id="content">';
echo '<h2>Tracks</h2>';
if ($result->num_rows > 0) {
    // output data of each row
    echo '<table class="query">';
    echo '<tr><th>Name</th><th>Artist</th><th>Album</th><th>Year</th></tr>';
    $row_count = $result->num_rows;
    while($row = $result->fetch_assoc()) {
    	echo "<tr><td><a href='track-page.php?link_track=".$row["kappale"]."'>" . $row["kappale"]. '</a></td><td>' . $row["esittaja"]. '</td><td>' . $row["levy"]. '</td><td>' . $row["julkaisuvuosi"]. '</td></tr>';
    }
    echo '</table>';
   

    
} else {
    echo "0 results";
}

$result2 = $conn->query($sql2);

if($result2->num_rows > 0){
    $row_count = $result2->num_rows;
    $a = $row_count / 5;
    ceil($a);
    for($b = 1; $b <= $a; $b++){
        ?><a href="Tracks?page=<?php echo $b; ?>"   ><?php echo $b." "; ?></a><?php
    }
}


$conn->close();
		echo '</div>';
	echo '</div>';
echo '</div>';

include("footer.php");

?>