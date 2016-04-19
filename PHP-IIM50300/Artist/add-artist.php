<?php

include ("../Init/header.php"); 

require_once($dbInit);


$errmsg = '';

if (isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}

if (isset($_POST['nimi']) AND isset($_POST['vuosi']) AND isset($_POST['maa'])){

	$name     = $_POST['nimi'];
	$year     = $_POST['vuosi'];
	$country  = $_POST['maa'];

	include($insertArtistQuery);

	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('ssi', $name, $country, $year);

	if ($stmt->execute()){
		echo "<h2>Artist added to database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$artists."';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during inserting.'); setTimeout(\"location.href = '".$addArtistForm."';\",0);</script>";
	}
}

include ($footer); 

?>
