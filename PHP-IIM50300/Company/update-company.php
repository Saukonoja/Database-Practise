<?php
include ("../Init/header.php");

require_once($dbInit);

 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi']) AND !empty($_POST['vuosi']) AND !empty($_POST['maa'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$country  = isset($_POST['maa'])  ? $_POST['maa']  : '';
		$id       = $_POST['id'];

		$sql = "UPDATE yhtio 
                                 SET nimi = ?, 
                                 maa_avain = (SELECT avain FROM maa WHERE nimi = ?), 
                                 vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = ?) 
                                 WHERE avain = ?;";
		 
		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('ssii', $name, $country, $year, $id);

		if ($stmt->execute()){
			echo "<h2>Company updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = '".$companies."';\",1000);</script>";
		}else{
			echo "<script>alert('There was an error during updating.'); setTimeout(\"location.href = '".$updateCompanyForm."';\",0);</script>";
		}
	}else{
		echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$updateCompanyForm."';\",0);</script>";
	}

} else if ($_POST['action'] == 'Delete company'){

	$id = $_POST['id'];

	$sql =  "DELETE FROM yhtio WHERE avain = ?;";
 
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);

	if ($stmt->execute()){
		echo "<h2>Company deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$companies."';\",1000);</script>";
	} else{
		echo "<script>alert('There was an error during deletion.'); setTimeout(\"location.href = '".$updateCompanyForm."';\",0);</script>";
	}

}

include ($footer);

?>
