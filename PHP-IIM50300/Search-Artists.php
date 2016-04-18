<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/search-all-artists-query.php");



include("artists-table.php");

include("footer.php");

?>