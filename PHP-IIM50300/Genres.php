<?php

include("header.php");

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

$_SESSION['current'] = "Genres";

require_once("db-init-music.php");

include("select-queries/all-genres-query.php");

include("genres-table.php");

include("footer.php");

?>