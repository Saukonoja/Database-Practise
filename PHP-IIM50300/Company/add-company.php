<?php

include ("../Init/header.php"); 

require_once($dbInit);


$errmsg = '';

if (isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}

if (!empty($_POST['nimi']) AND !empty($_POST['vuosi']) AND !empty($_POST['maa'])){

	try {
		$name     = $_POST['nimi'];
		$year     = $_POST['vuosi'];
		$country  = $_POST['maa'];

		$sql = "INSERT INTO yhtio (nimi, maa_avain, vuosi_avain) 
                                 VALUES (?, 
                                 (SELECT avain FROM maa WHERE nimi = ?), 
                                 (SELECT avain FROM vuosi WHERE vuosi = ?));";

		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('ssi', $name, $country, $year);

		if ($stmt->execute()){
			echo "<h2>Country added to database.</h2>";
			echo "<script>setTimeout(\"location.href = '".$companies."';\",1000);</script>";
		} else{
			echo "<script>alert('There was error during inserting.'); setTimeout(\"location.href = '".$addCompanyForm."';\",0);</script>";
		}
	}catch (Exception $e){
    	echo $e->getMessage();
	}
}else{
	echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$addCompanyForm."';\",0);</script>";
}

include ($footer); 

?>
