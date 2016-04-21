<?php

include("../Init/config.php");

require_once($passLib);

class Hash{

 function hashPassword($password){
		$lib = new PasswordLib\PasswordLib();
		$hash = $lib->createPasswordHash($password,  '$2a$', array('cost' => 12));
		return $hash;
 }

 function verifyPasword($password, $hash){
 		$lib = new PasswordLib\PasswordLib();
		$boolean = $lib->verifyPasswordHash($password, $hash);		 
		return $boolean;
	}
 }

?>