<?php

$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Login page</title>
   		<link rel="stylesheet" type="text/css" href="style.css">	
   </head>

   <body>
         <div id="formContainer">
              <form method="post" action="<?php echo $_SERVER;?>">
              <h2>Login</h2>
              <h3>Music Database</h3>
              Username:<br><input type='text' name="uid"><br>
              Password:<br><input type='text' name="passwd"><br>
              <button type='submit' action='name' class="buttons" id='btnLogin2'>Login</button>
              <button class='buttons' id='btnBack'>Back</button>
              <br>
              </form>

            </div>	  
 </body>
 </html>
CONTENT;


echo $content;

?>