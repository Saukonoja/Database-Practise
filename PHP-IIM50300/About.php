﻿<?php

require_once("db-init-music.php");

include("header.php");


echo '<h1>About us</h1>';
$output = <<<OUTPUT
	<p>This Music Database was produced during the course Server programming in Finnish school JAMK University of Applied Sciences. <br> 
	<p>This Music Database was produced during the course Server programming in finnish school JAMK University of Applied Sciences. <br> 
 	If you like to give us some feedback and ideas for improvement please contact us at:<br><br>Janne Hakala: H3298@student.jamk.fi <br> Timo Saukonoja: H3694@student.jamk.fi</p>
OUTPUT;

echo $output;

include("footer.php");

?>