<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/search-all-companies-query.php");



include("companies-table.php");

include("footer.php");

?>