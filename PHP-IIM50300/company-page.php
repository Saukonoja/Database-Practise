<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

if (isset($_GET['link_company'])){
        $_SESSION['company'] = $_GET['link_company'];
}

include("select-queries/company-albums-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h2>'.$_SESSION['company'].'</h2>';
if ($result->num_rows > 0) {
    echo '<table class="query">';
    echo '<tr><th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
              <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
              <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th></tr>';
    while($row = $result->fetch_assoc()) {
        $newCompanyAlbum = new CompanyView($row["album"], $row["artist"], $row['year']);
        echo $newCompanyAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>