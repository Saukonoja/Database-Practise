<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");
$_SESSION['current'] = "Artists";
include("select-queries/all-artists-query.php");

$result = $conn->query($sql);
$test = "fds";
echo '<h1 id="pageHeader">Artists</h1>';
echo '<form action=\'add-artist-form.php\'><button id=btnAdd class="buttons">Add artist</button></form>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
	echo '<tr><th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
			  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
			  <th><a href="?sort=country&sort_by='.$sort_order.'" id="headerLink">Country</a></th><th id= \'hiddenTh\'>ID</th></tr>';
    while($row = $result->fetch_assoc()) {
        $newArtist = new Artist($row["artist"], $row["year"], $row["country"], $row["ID"]);
        echo $newArtist;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

if ($_SESSION['islogged']==true){
   ?>
   <script type="text/javascript">document.getElementById('btnAdd').style.display = 'default';</script>
   <?php
}
else {
?>
    <script type="text/javascript">document.getElementById('btnAdd').style.display = 'none';</script>
<?php
}
include("footer.php");

?>