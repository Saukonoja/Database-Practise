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
            <div id="headerBar"><span id="title">Music database</span>
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

CONTENT;


echo $content;

?>