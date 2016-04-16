<?php
require_once("db-init-music.php");

include("header.php");

$output = <<<OUTPUT
	<h1>Welcome, guest!</h1>
	<p>This awesome database is still in the works of becoming the most used and greatest music database ever.<br>
	We hope that you can enjoy using this application and maybe contribute some data for everyone to view.</p>
OUTPUT;

echo $output;

include("footer.php");

?>