<?php
$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database</title>
   		<link rel="stylesheet" type="text/css" href="style.css">
         <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.css" rel="stylesheet">	
   </head>

   <body>
         <nav>
            <div id="headerBar"><a href="index" id="title-link"><span id="title"><i class="fa fa-home"></i></span></a>   Music database
               <button class="buttons" id="btnLogin" onclick="window.location.href='login-form.php'">LOGIN</button>
               <button class="buttons" id="btnSignUp" onclick="window.location.href='register-form.php'">SIGN UP</button>
            </div>
            <div id="searchBar">
               <form method='post' action='Search.php'>
                  <input id="inputSearch" type="text" placeholder="Search" name="search">
                  <input class="buttons" id="btnSearchFromDatabase" type="submit" name="btnSearchDatabase" value="Search from database">
               </form> 
            </div>            
         </nav>
         <div id="container">
            <div id="sideBar">
            	<table class="sidebar">
            	   <tr><td class="test" onclick="window.location.href='index'">Home</td></tr>
            		<tr><td onclick="window.location.href='Artists'">Artists</td></tr>
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