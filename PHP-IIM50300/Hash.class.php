<?php
	require_once 'PasswordLib.phar';

	class Hash{

		function hashPassword($password){
				$lib = new PasswordLib\PasswordLib();
				$hash = $lib->createPasswordHash($password,  '$2a$', array('cost' => 12));
				return $hash;
		}

		function verifyPasword($password, $hash){
	 		$lib = new PasswordLib\PasswordLib();
			if ($lib->verifyPasswordHash($password, $hash)){
				return true;
			}	 
			return false;
		}
	}	
?>