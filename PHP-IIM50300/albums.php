<?php

include("header.php");

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

$_SESSION['current'] = "Albums";
echo '<h1 id="pageHeader">Albums</h1>';
require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

include("albums-table.php");

include("footer.php");

?>