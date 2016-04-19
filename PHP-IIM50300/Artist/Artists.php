<?php
include("header.php");
include ('config.php');

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

$_SESSION['current'] = "Artists";

include("select-queries/all-artists-query.php");

$result = $conn->prepare($sql);
$result->execute();

include("artists-table.php");

include("footer.php");

?>