<?php

include("../Init/header.php");


require_once($genreViewClass);


require_once($dbInit);

if (isset($_GET['link_genre'])){
        $_SESSION['genre'] = $_GET['link_genre'];
}

echo '<h1>'.$_SESSION['genre'].'</h1>';

include($genreTracksQuery);

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=track&sort_by='.$sort_order.'" id="headerLink">Track</a></th>
              <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    while($row = $result->fetch_assoc()) {
        $newGenreTrack = new GenreView($row["track"], $row["artist"], $row['album'], $row['year']);
        echo $newGenreTrack;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include($footer);

?>