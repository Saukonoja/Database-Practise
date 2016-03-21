<?php

$content = <<<CONTENT


<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Front page</title>
   		<link rel="stylesheet" type="text/css" href="style.css">
        <link rel="shortcut icon" href="https://image.freepik.com/free-icon/square-brackets_318-11293.png"> 	
   </head>

   <body>
         <nav>
         	<div id="headerBar">Music database
            	<button class="buttons" id="btnLogin">LOGIN</button>
            	<button class="buttons" id="btnSignUp">SIGN UP</button>
         	</div>
            <div id="searchBar">
               <form>
                  <input id="inputSearch" type="text" name="search">
                  <input class="buttons" id="btnSearchFromDatabase" type="submit" name="btnSearchDatabase" value="Search from database">
               </form> 
            </div>    	   	
         </nav>
        
         <div id="sideBar">
         	<table>
         		<tr><td>Home</td></tr>
         		<tr><td>Artists</td></tr>
         		<tr><td>Albums</td></tr>
         		<tr><td>Tracks</td></tr>
         		<tr><td>Genres</td></tr>
         		<tr><td>Record companies</td></tr>
         		<tr><td>About</td></tr>
         	</table>
         </div>	  

         <footer>
	         	<div id="footerText">&copy; Music database 2016
	         	<button class="buttons" id="btnContact">Contact us</button></div>
	     </footer>
   </body>
</html>

CONTENT;


echo $content;

?>