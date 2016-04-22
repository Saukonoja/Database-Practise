<?php
include ("../Init/header.php");

require_once($dbInit);

 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi']) AND !empty($_POST['vuosi']) AND !empty($_POST['maa'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$country  = isset($_POST['maa'])  ? $_POST['maa']  : '';
		$id       = $_POST['id'];

		include($updateArtistQuery);
		 
		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('ssii', $name, $country, $year, $id);

		if ($stmt->execute()){
			echo "<h2>Artist updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = '".$artists."';\",1000);</script>";
		} else{
			echo "<script>alert('There was an error during updating.'); setTimeout(\"location.href = '".$updateArtistForm."';\",0);</script>";
		}
	}else{
		echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$updateArtistForm."';\",0);</script>";
	}

} else if ($_POST['action'] == 'Delete artist'){

	$id = $_POST['id'];

	include($deleteArtistQuery);
 
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);

	if ($stmt->execute()){
		echo "<h2>Artist deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$artists."';\",1000);</script>";
	} else{
		echo "<script>alert('There was an error during deletion.'); setTimeout(\"location.href = '".$updateArtistForm."';\",0);</script>";
	}

}

include ($footer);

?>
