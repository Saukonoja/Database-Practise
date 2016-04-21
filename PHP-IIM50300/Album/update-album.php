<?php
include ("../Init/header.php");

require_once($dbInit);


 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi']) AND !empty($_POST['esittaja']) AND !empty($_POST['vuosi']) AND !empty($_POST['yhtio'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$artist     = isset($_POST['esittaja'])   ? $_POST['esittaja']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$company  = isset($_POST['yhtio'])  ? $_POST['yhtio']  : '';
		$imglink  = isset($_POST['imglink']) ? $_POST['imglink'] : '';
		$id       = $_POST['id'];


		include($updateAlbumQuery);
		 
		$stmt = $conn->prepare($sql);
		$stmt->bind_param('ssiss', $name, $company, $year, $imglink, $id);
		$stmt->execute();
		$stmt = $conn->prepare("UPDATE cd_esittaja 
             SET esittaja_avain = (SELECT avain FROM esittaja WHERE nimi = ?)
             WHERE cd_avain = ?");
		$stmt->bind_param('ss', $artist, $id);

		if ($stmt->execute()){
			echo "<h2>Album updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = 'Albums.php';\",1000);</script>";
		} else{
			echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = 'update-album-form.php';\",0);</script>";
		}
	}

} else if ($_POST['action'] == 'Delete artist'){

	$id = $_POST['id'];

	$sql = "DELETE FROM cd_esittaja WHERE cd_avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt->bind_param('s', $id);
	$stmt->execute();

	$sql = "DELETE FROM cd_kappale WHERE cd_avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt->bind_param('s', $id);
	$stmt->execute();

	$sql = "DELETE FROM cd WHERE avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt->bind_param('s', $id);
	$stmt->execute();

	if ($stmt->execute()){
		echo "<h2>Album deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = 'Albums.php';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during deletion.'); setTimeout(\"location.href = 'update-album-form.php';\",0);</script>";
	}

}

include ($footer);

?>