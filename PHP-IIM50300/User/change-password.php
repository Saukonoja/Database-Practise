<?php

include("../Init/header.php");

require_once($hashClass);
require_once($validatorClass);


require_once($dbInit);

if (!empty($_POST['password']) AND !empty($_POST['re-password'])){
		$validator = new Validator();
		$hash = new Hash();

		$password = isset($_POST['password']) ? $_POST['password'] : '';
		$repassword = isset($_POST['re-password']) ? $_POST['re-password'] : '';

	try{
		if ($password == $repassword){

			if ($validator->CheckPassword($password)){
				$hashedPass = $hash->hashPassword($password);

				$sql =
				"UPDATE user SET salasana = ?
				WHERE tunnus = ?;";
		 
				$stmt = $conn->prepare("$sql");
				$stmt->bind_param('ss', $hashedPass, $_SESSION['username']);

				if ($stmt->execute()){
						echo "<h2>Password changed succesfully.</h2>";
						echo "<script>setTimeout(\"location.href = '".$loginForm."';\",1500);</script>";
					} else{
						$_SESSION['errorMsg'] = "error";
						header("Location : ".$users);
					}
			}else{
				$_SESSION['errorMsg'] = "Valid password: 8-20 characters. No special characters. Passwords must match.";
				header("Location : ".$users);		
			}

		}else{
			$_SESSION['errorMsg'] = "Passwords must match.";
			header("Location : ".$users);		
		}
	}catch (Exception $e){
    	echo $e->getMessage();
    } 
}else{
	$_SESSION['errorMsg'] = "Fill fields first.";
	header("Location : ".$users);		
}

include($footer);

?>
