<?php
$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database</title>
   		<link rel="stylesheet" type="text/css" href="style.css">	
   </head>

   <body>
         <nav>
            <div id="headerBar"><a href="index" id="title-link"><span id="title">Music database</span></a>
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
            	   <tr><td class="test" onclick="window.location.href='index'">Home</td></tr>
            		<tr><td onclick="window.location.href='artists'">Artists</td></tr>
            		<tr><td onclick="window.location.href='Albums'">Albums</td></tr>
            		<tr><td onclick="window.location.href='Tracks'">Tracks</td></tr>
            		<tr><td onclick="window.location.href='Genres'">Genres</td></tr>
            		<tr><td onclick="window.location.href='Companies'">Record companies</td></tr>
            		<tr><td onclick="window.location.href='About'">About</td></tr>
            	</table>
            </div>	  
            <div id="content-layout">
            <div id="content">

CONTENT;


echo $content;

?>