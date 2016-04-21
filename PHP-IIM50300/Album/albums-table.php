<?php

echo '<h1 id="pageHeader">Albums</h1>';
echo '<form action=\'add-album-form.php\'><button id=btnAdd class="buttons" style='.$display.'>Add album</button></form>';
if ($result->bind_result($album, $artist, $year, $company, $id)) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
        <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
        <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
        <th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Record company</a></th>
        <th id= \'hiddenTh\'>ID</th></tr>';
    while($result->fetch()) {   
        $newAlbum = new Album($album, $artist, $year, $company, $id);
        echo $newAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

?>