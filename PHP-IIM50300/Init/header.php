
<?php
session_start();

if (!isset($_SESSION['islogged'])){
   $_SESSION['islogged'] = false;
}

if (empty($_SESSION['username'])){
   $_SESSION['username'] = '';
}


if ($_SESSION['islogged'] == true){
   $display = 'display:default;';
}else{
   $display = 'display:none;';
}


if ($_SESSION['islogged'] == false){


   $display2 = 'display:default';
}else{
   $display2 = 'display:none';
}


if (isset($_SESSION['errorMsg'])){
  $error = $_SESSION['errorMsg'];
  session_unset($_SESSION["errorMsg"]);
}else{
  $error = "";
}

include("config.php");


$content = <<<CONTENT
<!DOCTYPE html>

<html>
   <head>
   		<title>Music database</title>
   		<link rel="stylesheet" type="text/css" href={$style}>
         <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.css" rel="stylesheet">	
   </head>

   <body>
         <nav>
            <div id="headerBar"><a href="{$index}" id="title-link"><span id="title"><i class="fa fa-home"></i></span></a>   Music database        
               <button class="buttons" id="btnLogin" onclick="window.location.href='{$loginForm}'" style="{$display2}">LOGIN</button>
               <button class="buttons" id="btnSignUp" onclick="window.location.href='{$registerForm}'" style="{$display2}">SIGN UP</button>
               <button class="buttons" id="btnLogout" onclick="window.location.href='{$logout}'" style="{$display}">LOG OUT</button>
               <p id='loggedAs' style="{$display}">Logged in as {$_SESSION['username']}</p>
            </div>
            <div id="searchBar">

               <form method='post' action='{$searchLink}'>

                  <input id="inputSearch" type="text" autocomplete="off" placeholder="Search" name="search">
                  <input class="buttons" id="btnSearchFromDatabase" type="submit" name="btnSearchDatabase" value="Search from database">
               </form> 
            </div>            
         </nav>
         <div id="container">
            <div id="sideBar">
            	<table class="sidebar">
            	   <tr><td class="test" onclick="window.location.href='{$index}'">Home</td></tr>
            		<tr><td onclick="window.location.href='{$artists}'">Artists</td></tr>
            		<tr><td onclick="window.location.href='{$albums}'">Albums</td></tr>
            		<tr><td onclick="window.location.href='{$tracks}'">Tracks</td></tr>
            		<tr><td onclick="window.location.href='{$genres}'">Genres</td></tr>
            		<tr><td onclick="window.location.href='{$companies}'">Record companies</td></tr>
            		<tr><td onclick="window.location.href='{$about}'">About</td></tr>
                  <tr><td onclick="window.location.href='{$users}'" style="{$display}">Users</td></tr>
            	</table>
            </div>	  
            <div id="content-layout">
            <div id="content">

CONTENT;

echo $content;


?>