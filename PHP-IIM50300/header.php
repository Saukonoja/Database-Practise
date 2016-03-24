<?php

$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database | Front page</title>
   		<link rel="stylesheet" type="text/css" href="style.css">	
   </head>

   <body>
         <nav>
            <div id="headerBar"><a href="index.php" id="title-link"><span id="title">Music database</span></a>
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
         <div id="container">
            <div id="sideBar">
            	<table class="sidebar">
            	   <tr><td class="test" onclick="window.location.href='index.php'">Home</td></tr>
            		<tr><td onclick="window.location.href='artists.php'">Artists</td></tr>
            		<tr><td onclick="window.location.href='albums.php'">Albums</td></tr>
            		<tr><td>Tracks</td></tr>
            		<tr><td>Genres</td></tr>
            		<tr><td>Record companies</td></tr>
            		<tr><td>About</td></tr>
            	</table>
            </div>	  

CONTENT;


echo $content;

?>