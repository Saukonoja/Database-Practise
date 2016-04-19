<?php
echo '<h1 id="pageHeader">Artists</h1>';
echo '<form action=\'add-artist-form.php\'><button id=btnAdd class="buttons">Add artist</button></form>';
if ($result->bind_result($artist, $year, $country, $id)) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
              <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th>
              <th id= \'hiddenTh\'>ID</th></tr>';
    while($result->fetch()) {
        $newArtist = new Artist($artist, $year, $country, $id);
        echo $newArtist;
    }
    echo '</table>';
} else {
    echo "0 results";
}

$conn->close();
?>