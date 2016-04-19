<?php
include ("header.php");
require_once("db-init-music.php");


 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi']) AND !empty($_POST['vuosi']) AND !empty($_POST['maa'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$country  = isset($_POST['maa'])  ? $_POST['maa']  : '';
		$id       = $_POST['id'];

		include("update-queries/update-artist-query.php");
		 
		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('ssii', $name, $country, $year, $id);

		if ($stmt->execute()){
			echo "<h2>Artist updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = 'Artists.php';\",1000);</script>";
		} else{
			echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = 'update-artist-form.php';\",0);</script>";
		}
	}

} else if ($_POST['action'] == 'Delete artist'){

	$id = $_POST['id'];

	include("delete-queries/delete-artist-query.php");
 
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);

	if ($stmt->execute()){
		echo "<h2>Artist deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = 'Artists.php';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during deletion.'); setTimeout(\"location.href = 'update-artist-form.php';\",0);</script>";
	}

}

include ("footer.php");

?>
