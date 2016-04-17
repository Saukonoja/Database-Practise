<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();

$_SESSION['current'] = "Tracks";

require_once("db-init-music.php");

include("select-queries/all-tracks-query.php");

include("tracks-table.php");

include("footer.php");

?>
