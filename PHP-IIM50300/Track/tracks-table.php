<?php
$result->bind_result($track, $artist, $album, $year, $id);

echo '<form action=\'add-track-form.php\'><button id=btnAdd class="buttons" style='.$display.'>Add track</button></form>';

if ($result) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=track&sort_by='.$sort_order.'" id="headerLink">Track</a></th>
              <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
              <th id= \'hiddenTh\'>ID</th></tr>';
    while($result->fetch()) {
        $newTrack = new Track($track, $artist, $album, $year, $id);
        echo $newTrack;
    }
    echo '</table>';
    
} else {
    echo "0 results";
}

include($allTracksCountQuery);

$result2 = $conn->query($sql2);

$prev = $page - 1;
$next = $page + 1;

echo '<br>';
echo '<div id="linkContainer">';
if ($page > 1){
    echo "<a href='".$tracks."?page=$prev' id='prevLink'>Prev</a>";
}

if ($result2->num_rows > 0){
    $row_count = $result2->num_rows;
    $decimal = $row_count / 10;

    $numberOfPages = ceil($decimal);

    for($i = 1; $i <= $numberOfPages; $i++){
        echo ($i == $page) ? "<b><a href='".$tracks."?page=". $i. "' id='pageCurrentLink'>" .$i. "</a></b>" : "<a href='".$tracks."?page=". $i. "' id='pageLink'>" .$i. "</a>";
    }
}

if ($page < $numberOfPages){
    echo "<a href='".$tracks."?page=$next' id='nextLink'>Next</a>";
}
echo '</div>';

$conn->close();

?>