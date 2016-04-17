<?php
session_start();

if (isset($_POST['search'])){
    $_SESSION['search']=$_POST['search'];
}


if ($_SESSION['current'] == 'Artists'){
    include("Search-Artists.php");
}

if ($_SESSION['current'] == 'Albums'){
    include("Search-Albums.php");
}

if ($_SESSION['current'] == 'Tracks'){
    include("Search-Tracks.php");
}
?>