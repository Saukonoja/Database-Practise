<?php
include("../Init/header.php"); 

require_once($dbInit);

$errmsg = '';

if (isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}

if (!empty($_POST['nimi']) AND !empty($_POST['esittaja']) AND !empty($_POST['vuosi']) AND !empty($_POST['cd'])){

	$name     = $_POST['nimi'];
	$artist   = $_POST['esittaja'];
	$year     = $_POST['vuosi'];
	$album  = $_POST['cd'];
	$genre  = $_POST['genre'];
	$tube  = $_POST['tube'];
	$number  = $_POST['number'];
	$length  = $_POST['length'];

	$tubeparsed = substr($tube, strpos($tube, "=") + 1);

	$sql1 ="INSERT INTO kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero)
                                 VALUES (?, ?, 
                                 (SELECT avain FROM esittaja WHERE nimi = ?),
                                 (SELECT avain FROM vuosi WHERE vuosi = ?), ?, ?);";                         

	
	$sql2 =	"INSERT INTO cd_kappale (cd_avain, kappale_avain) 
                                 VALUES ((SELECT avain FROM cd WHERE nimi = ?), 
                                 (SELECT avain FROM kappale WHERE nimi = ?));";

	$sql3 = "INSERT INTO kappale_genre (kappale_avain, genre_avain) 
                                 VALUES ((SELECT avain FROM kappale WHERE nimi = ?), 
                                 (SELECT avain from genre WHERE nimi = ?));";

	$stmt = $conn->prepare("$sql1");
	$stmt-> bind_param('sssisi', $name, $length, $artist, $year, $tubeparsed, $number);
	$stmt->execute();
	$stmt = $conn->prepare("$sql2");
	$stmt-> bind_param('ss', $album, $name);
	$stmt->execute();
	$stmt = $conn->prepare("$sql3");
	$stmt-> bind_param('ss', $name, $genre);

	if ($stmt->execute()){
		echo "<h2>Track added to database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$tracks."';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during inserting.'); setTimeout(\"location.href = '".$addTrackForm."';\",0);</script>";
	}
}else{
	echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$addTrackForm."';\",0);</script>";
}

include ($footer); 

?>
