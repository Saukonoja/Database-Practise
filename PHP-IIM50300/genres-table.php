<?php

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=genre&sort_by='.$sort_order.'" id="headerLink">Genre</a></th></tr>';
    while($row = $result->fetch_assoc()) {
        $newGenre = new Genre($row["genre"]);
        echo $newGenre;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();


?>