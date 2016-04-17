<body style="background: gray">

<?php
session_start();

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

if (!empty($_POST['username']) AND !empty($_POST['password']) AND !empty($_POST['re-password'])){
		$validator = new Validator();

		$username   = isset($_POST['username'])  ? $_POST['username']   : '';
		$password = isset($_POST['password']) ? $_POST['password'] : '';
		$repassword = isset($_POST['re-password']) ? $_POST['re-password'] : '';

		if ($password == $repassword){

			if ($validator->ValidateRegister($username, $password)){

				$sql = <<<SQLEND
				INSERT INTO user (tunnus, salasana, tyyppi)
				VALUES(?,?,0)
SQLEND;
		 
				$stmt = $conn->prepare("$sql");
				$stmt-> bind_param('ss', $username, $password);

				if ($stmt->execute()){
						echo "<h2 style='text-align:center;'>Registration successfull.</h2>";
						echo "<h3 style='text-align:center;'>Redirecting to login...</h3>";
						echo "<script>setTimeout(\"location.href = 'login-form.php';\",2500);</script>";
					} else{
						$_SESSION['registerError'] = "Username already exists.";
						header("Location : register-form.php");
				}
			}else{
				$_SESSION['registerError'] = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\n No special characters.\nPasswords must match.";
				header("Location : register-form.php");		
			}

		}else{
			$_SESSION['registerError'] = "Passwords must match.";
			header("Location : register-form.php");		
		}

}else{
	$_SESSION['registerError'] = "Fill fields first.";
	header("Location : register-form.php");		
}

?>

</body>