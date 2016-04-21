<?php

echo '<h1 id="pageHeader">Genres</h1>';
$result->bind_result($genre);
if ($result) {
    
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=genre&sort_by='.$sort_order.'" id="headerLink">Genre</a></th></tr>';
    while($result->fetch()) {
        $newGenre = new Genre($genre);
        echo $newGenre;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

?>