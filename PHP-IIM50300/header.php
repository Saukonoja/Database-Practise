﻿<?php
session_start();

if(empty($_SESSION['username'])){
$_SESSION['username'] = '';
}

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
               <button class="buttons" id="btnLogout" onclick="window.location.href='logout.php'">LOG OUT</button>
               <p id='loggedAs'>Logged in as {$_SESSION['username']}</p>
            </div>
            <div id="searchBar">
               <form method='post' action='Search.php'>
                  <input id="inputSearch" type="text" autofocus autocomplete="off" placeholder="Search" name="search">
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

if(!isset($_SESSION['islogged'])){
   $_SESSION['islogged'] = false;
}

if ($_SESSION['islogged']==true){
   ?>
   <script type="text/javascript">document.getElementById('btnLogin').style.display = 'none';</script>
   <script type="text/javascript">document.getElementById('btnSignUp').style.display = 'none';</script>
   <script type="text/javascript">document.getElementById('btnLogout').style.display = 'default';</script>
   <script type="text/javascript">document.getElementById('loggedAs').style.display = 'default';</script>   
   <?php
}
else {
?>
<script type="text/javascript">document.getElementById('btnLogin').style.display = 'default';</script>
<script type="text/javascript">document.getElementById('btnLogin').style.display = 'default';</script> 
<script type="text/javascript">document.getElementById('btnLogout').style.display = 'none';</script>
<script type="text/javascript">document.getElementById('loggedAs').style.display = 'none';</script>  
<?php
}

?>