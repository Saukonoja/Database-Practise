
<?php
session_start();

include("../Init/config.php");

if (isset($_SESSION['registerError'])){
  $error = $_SESSION['registerError'];
  session_unset($_SESSION["registerError"]);
}else{
  $error = "";
}


$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Register page</title>
      <link rel="stylesheet" type="text/css" href="{$style}">
   </head>
   
   <body> 
   <div id="errorMessageContainer">
     <div id=errorMessage>{$error}</div>
   </div>
         <div id="formContainerLoginRegister">
              <form method="post" action="register.php">
                <h1>Register</h1>
                <h3>Music Database</h3>
                Username:<br><input type='text' autocomplete="off" autofocus name="username"><br>
                Password:<br><input type='password' name="password"><br>
                Re-enter password:<br><input type='password' name="re-password"><br>
                <input type="submit" name="action" value='Register' class='buttons' id='btnRegisterLoginForm' onclick="javascript: return confirm('Confirm registration.')"><br>    
              </form> 
              <button class='buttons' id='btnBackToLogin' onclick="window.location.href='{$loginForm}'">Back to Login</button><br>
              <button class='buttons' id='btnBackToMain' onclick="window.location.href='{$index}'">Back to Music database</button>      
          </div>	  
    </body>
 </html>

CONTENT;
echo $content;

?>