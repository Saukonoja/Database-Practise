<?php

	class Validator{
 
        function ValidateRegister($username, $password){
        	if ($this->CheckUserName($username) && $this->CheckPassword($password)){
        		return true;
        	}
        	return false;
        }

         function ValidateLogin($username, $password){
        	if ($this->CheckUserName($username) && $this->CheckPassword($password)){
        		return true;
        	}
        	return false;
        }

        function CheckUserName($username){
        	$noSpecials = preg_match('/^[A-Za-z0-9]+$/', $username);
        	if ((strlen($username) >= 5 && strlen($username) <= 20) && $noSpecials){
        		return true;
        	}
        	return false;
    	}

    	function CheckPassword($password){
    		$noSpecials = preg_match('/^[A-Za-z0-9]+$/', $password);
        	if ((strlen($password) >= 8 && strlen($password) <= 20) && $noSpecials){
        		return true;
        	}
        	return false;
    	}
    }

?>