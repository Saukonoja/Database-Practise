<?php
include ("../Init/header.php");

require_once($dbInit);

 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$country  = isset($_POST['maa'])  ? $_POST['maa']  : '';
		$id       = $_POST['id'];

		$sql = "UPDATE genre SET nimi = ? WHERE avain = ?;";
		 
		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('si', $name, $id);

		if ($stmt->execute()){
			echo "<h2>Genre updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = '".$genres."';\",1000);</script>";
		} else{
			echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = 'update-genre-form.php';\",0);</script>";
		}
	}

} else if ($_POST['action'] == 'Delete genre'){

	$id = $_POST['id'];

	$sql = "DELETE FROM genre WHERE avain = ?";
 
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);

	if ($stmt->execute()){
		echo "<h2>Genre deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$genres."';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during deletion.'); setTimeout(\"location.href = 'update-genre-form.php';\",0);</script>";
	}

}

include ($footer);

?>
