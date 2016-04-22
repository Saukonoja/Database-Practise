<?php

include ("../Init/header.php"); 

require_once($dbInit);


$errmsg = '';

if (isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}

if (isset($_POST['nimi'])){

	try {
		$name     = $_POST['nimi'];
		$sql="INSERT INTO genre (nimi) VALUES (?);";

		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('s', $name);

		if ($stmt->execute()){
			echo "<h2>Genre added to database.</h2>";
			echo "<script>setTimeout(\"location.href = '".$genres."';\",1000);</script>";
		} else{
			echo "<script>alert('There was error during inserting.'); setTimeout(\"location.href = 'add-genre-form.php';\",0);</script>";
		}
	}catch (Exception $e){
    	echo $e->getMessage();
	}
}

include ($footer); 

?>
