<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/search-all-genres-query.php");

include("header.php");

include("genres-table.php");

include("footer.php");


?>