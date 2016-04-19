
<?php

include("header.php");

require_once 'Hash.class.php';
require_once 'Validator.class.php';


require_once("db-init-music.php");

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
						echo "<script>setTimeout(\"location.href = 'login-form.php';\",2000);</script>";
					} else{
						$_SESSION['errorMsg'] = "error";
						header("Location : Users.php");
					}
			}else{
				$_SESSION['errorMsg'] = "Valid password: 8-20 characters. No special characters. Passwords must match.";
				header("Location : Users.php");		
			}

		}else{
			$_SESSION['errorMsg'] = "Passwords must match.";
			header("Location : Users.php");		
		}
	}catch (Exception $e){
    	echo $e->getMessage();
    } 
}else{
	$_SESSION['errorMsg'] = "Fill fields first.";
	header("Location : Users.php");		
}

include("footer.php");

?>
