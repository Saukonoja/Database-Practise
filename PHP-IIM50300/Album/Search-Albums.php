<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/search-all-albums-query.php");

$result = $conn->prepare($sql);
$result -> bind_param('ssss', $search, $search, $search, $search);
$result -> execute();

include("albums-table.php");

include("footer.php");

?>