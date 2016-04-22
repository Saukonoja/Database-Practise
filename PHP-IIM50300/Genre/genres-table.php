<?php


echo '<h1 id="pageHeader">Genres</h1>';
$result->bind_result($genre, $id);
if ($result) {
    echo '<form action=\'add-genre-form.php\'><button id=btnAdd class="buttons" style='.$display.'>Add genre</button></form>';
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=genre&sort_by='.$sort_order.'" id="headerLink">Genre</a></th>
    <th id= \'hiddenTh\'>ID</th></tr>';
    while($result->fetch()) {
        $newGenre = new Genre($genre, $id);

        echo $newGenre;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();


?>