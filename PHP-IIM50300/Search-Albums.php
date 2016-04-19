<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/search-all-albums-query.php");



include("albums-table.php");

include("footer.php");

?>