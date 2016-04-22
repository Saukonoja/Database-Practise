<?php
include("Init/header.php");

$_SESSION['current'] = "Index";

if (!empty($_SESSION['username'])){
	$currentUser = $_SESSION['username'];
}
else{
	$currentUser = "Guest";
}

$file = "counter.txt";

if (!file_exists($file)) {
  $f = fopen($file, "w");
  fwrite($f,"0");
  fclose($f);
}

$f = fopen($file,"r");
$visitorNumber = fread($f, filesize($file));
fclose($f);

if (!isset($_SESSION['hasVisited'])){
  $_SESSION['hasVisited']="yes";
  $visitorNumber++;
  $f = fopen($file, "w");
  fwrite($f, $visitorNumber);
  fclose($f); 
}

if (isset($_COOKIE['counter'])) {
   $counter = $_COOKIE['counter'];
   $counter++;
} else {
   $counter = 1;
}

setcookie ("counter", "$counter" ,time() + (86400 * 30));

$output = <<<OUTPUT

	<br><h1>Welcome, {$currentUser} !</h1>
  <h3 style="color:black;">You are visitor number {$visitorNumber} on this site.</h3>
  <h3 style="color:black;">Your visits on this site {$counter}.</h3>
	<p>This awesome database is still in the works of becoming the most used and greatest music database ever.<br>
	We hope that you can enjoy using this application and maybe contribute some data for everyone to view.</p>
OUTPUT;
echo $output;
include("Init/footer.php");
?>

