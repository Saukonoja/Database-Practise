<?php
include("../Init/header.php"); 

require_once($dbInit);


$errmsg = '';

if (isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}

if (!empty($_POST['nimi']) AND !empty($_POST['esittaja']) AND !empty($_POST['vuosi']) AND !empty($_POST['yhtio'])){

	$name     = $_POST['nimi'];
	$artist   = $_POST['esittaja'];
	$year     = $_POST['vuosi'];
	$company  = $_POST['yhtio'];
	$imglink  = $_POST['imglink'];

	$sql1 ="insert into cd (nimi, yhtio_avain, vuosi_avain, kuvapath)
		values (?,(select avain from yhtio where nimi = ?),
		(select avain from vuosi where vuosi = ?),?);";

	$sql2 =
		"insert into cd_esittaja(cd_avain, esittaja_avain)
		values ((select avain from cd where nimi = ?),
		(select avain from esittaja where nimi = ?));
		";

	$stmt = $conn->prepare("$sql1");
	$stmt-> bind_param('ssis', $name, $company, $year, $imglink);
	$stmt->execute();
	$stmt2 = $conn->prepare("$sql2");
	$stmt2-> bind_param('ss', $name, $artist);

	if ($stmt2->execute()){
		echo "<h2>Album added to database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$albums."';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during inserting.'); setTimeout(\"location.href = '".$addAlbumForm."';\",0);</script>";
	}
}else{
	echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$addAlbumForm."';\",0);</script>";
}

include ($footer); 

?>
