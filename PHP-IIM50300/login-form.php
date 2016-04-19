<?php

session_start();

if (isset($_SESSION['loginError'])){
  $error = $_SESSION['loginError'];
  session_unset($_SESSION["loginError"]);
}else{
  $error = "";
}

$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Login page</title>
   		<link rel="stylesheet" type="text/css" href="style.css">	
   </head>

   <body> 
   <div id="errorMessageContainer">
     <div id=errorMessage>{$error}</div>
   </div>
         <div id="formContainerLoginRegister">
              <form method="post" action="login.php">
                <h1>Login</h1>
                <h3>Music Database</h3>
                Username:<br><input type='text' autofocus name="username" autocomplete='off'><br>
                Password:<br><input type='password' name="password"><br><br>
                <a href="register-form.php" id="accountQ">Don't have an account? Register here.</a><br>
                <input type='submit' name='action' value='Login' class="buttons" id='btnRegisterLoginForm'/><br>    
              </form>
              <button id='btnBackToMain' class='buttons' onclick="window.location.href='index.php'">Back to Music database</button>
          </div>	  
    </body>
 </html>

CONTENT;
echo $content;

?>