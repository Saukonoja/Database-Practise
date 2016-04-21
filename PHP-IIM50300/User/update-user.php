<?php

include ("../Init/header.php");

require_once($dbInit);

if ($_POST['action'] == 'Save changes'){

	if (!empty($_POST['username'])){
		$username     = isset($_POST['username'])   ? $_POST['username']   : '';
		$admin     = isset($_POST['admin']) ? '1' : '0';
		$id       = $_POST['id'];

		include($updateUserQuery);
		 
		$stmt = $conn->prepare("$sql");
		$stmt-> bind_param('sii', $username, $admin, $id);

		if ($stmt->execute()){
			echo "<h2>User updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = 'Users.php';\",1000);</script>";
		} else{
			echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = 'update-user-form.php';\",0);</script>";
		}
	}

} else if ($_POST['action'] == 'Delete user'){

	$id = $_POST['id'];

	include($deleteUserQuery);
 
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('i', $id);

	if ($stmt->execute()){
		echo "<h2>User deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$users."';\",1000);</script>";
	} else{
		echo "<script>alert('There was error during deletion.'); setTimeout(\"location.href = '".$updateUserForm."';\",0);</script>";
	}

}

include ($footer);

?>