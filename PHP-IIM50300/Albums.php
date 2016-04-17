﻿<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();

$_SESSION['current'] = "Albums";

require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

include("header.php");

include("albums-table.php");

include("footer.php");

?>