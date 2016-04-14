<?php

$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Register page</title>
   		<link rel="stylesheet" type="text/css" href="style.css">	
   </head>

   <body>
         <div id="formContainer">
              <form method="post" action="register.php">
              <h2>Register</h2>
              <h3>Music Database</h3>
              Username:<br><input type='text' name="username"><br>
              Password:<br><input type='password' name="password"><br>
              <button class='buttons' id='btnLogin2' onclick="javascript: return confirm('Send form?')">Register</button>
              <button class='buttons' id='btnBack'>Back</button>
              <br>
              </form>

            </div>	  
 </body>
 </html>
CONTENT;
echo $content;

?>