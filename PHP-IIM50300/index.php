<?php
require_once("db-init-music.php");

include("header.php");

$output = <<<OUTPUT
	<div id="content-layout">
			<p>home</p>
		</div>
	</div>
OUTPUT;

echo $output;

include("footer.php");

?>