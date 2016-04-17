<?php
include("header.php");
require_once("db-init-music.php");
if(!empty($_SESSION['username'])){
	$currentUser = $_SESSION['username'];
}
else{
	$currentUser = "Guest";
}

$output = <<<OUTPUT
	<h1>Welcome, {$currentUser} !</h1>
	<p>This awesome database is still in the works of becoming the most used and greatest music database ever.<br>
	We hope that you can enjoy using this application and maybe contribute some data for everyone to view.</p>
OUTPUT;
echo $output;

include("footer.php");

?>