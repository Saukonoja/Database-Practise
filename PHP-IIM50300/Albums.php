<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}


$_SESSION['current'] = "Albums";

require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

$result = $conn->prepare($sql);
$result -> execute();

include("albums-table.php");


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