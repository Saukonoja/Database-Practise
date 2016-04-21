<body style="background: gray">

<?php

session_start();

include("../Init/config.php");

require_once($hashClass);
require_once($validatorClass);

require_once($dbInit);

if (!empty($_POST['username']) AND !empty($_POST['password']) AND !empty($_POST['re-password'])){
		$validator = new Validator();
		$hash = new Hash();

		$username   = isset($_POST['username'])  ? $_POST['username']   : '';
		$password = isset($_POST['password']) ? $_POST['password'] : '';
		$repassword = isset($_POST['re-password']) ? $_POST['re-password'] : '';
	try{
		if ($password == $repassword){

			if ($validator->ValidateRegister($username, $password)){
				$hashedPass = $hash->hashPassword($password);

				$sql =
				"INSERT INTO user (tunnus, salasana, tyyppi)
				VALUES(?,?,0);";
		 
				$stmt = $conn->prepare("$sql");
				$stmt-> bind_param('ss', $username, $hashedPass);

				if ($stmt->execute()){
						echo "<h2 style='text-align:center;'>Registration successfull.</h2>";
						echo "<h3 style='text-align:center;'>Redirecting to login...</h3>";
						echo "<script>setTimeout(\"location.href = '".$loginForm."';\",2000);</script>";
					} else{
						$_SESSION['registerError'] = "Username already exists.";
						header("Location : ".$registerForm);
					}
			}else{
				$_SESSION['registerError'] = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\n No special characters.\nPasswords must match.";
				header("Location : ".$registerForm);		
			}

		}else{
			$_SESSION['registerError'] = "Passwords must match.";
			header("Location : ".$registerForm);		
		}
	}catch (Exception $e){
    	echo $e->getMessage();
    } 
}else{
	$_SESSION['registerError'] = "Fill fields first.";
	header("Location : ".$registerForm);		
}

?>

</body>