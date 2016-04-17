<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();

$_SESSION['current'] = "Companies";

require_once("db-init-music.php");

include("select-queries/all-companies-query.php");

include("header.php");

include("companies-table.php");

include("footer.php");

?>